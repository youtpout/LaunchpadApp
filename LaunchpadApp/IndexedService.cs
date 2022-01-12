using LaunchpadContract.Contracts.Launchpad.ContractDefinition;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Nethereum.Web3;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LaunchpadApp
{
    public class IndexedService : BackgroundService
    {

        private readonly IConfiguration config;
        public const string contractAddress = "0xFd553404A262FEb94c08FCe4b086A212BA5F4efF";
        // it's a POC, don't try this at home
        public static Dictionary<BigInteger, PresalesOutputDTO> presales = new Dictionary<BigInteger, PresalesOutputDTO>();

        public IndexedService(IConfiguration config)
        {
            this.config = config;
        }

        protected override async Task ExecuteAsync(CancellationToken stopToken)
        {
            string apiKey = config.GetValue<string>("apiKey");
            var web3 = new Web3($"https://bsc.getblock.io/testnet/?api_key={apiKey}");

            var presaleCountHandler = web3.Eth.GetContractQueryHandler<PresalesCountFunction>();
            var count = await presaleCountHandler.QueryAsync<BigInteger>(contractAddress, new PresalesCountFunction());

            for (int i = 0; i < ((int)count); i++)
            {
                await GetPresale(web3, i);
            }

            //Do your preparation (e.g. Start code) here
            while (!stopToken.IsCancellationRequested)
            {
                var transferEventHandler = web3.Eth.GetEvent<PresaleCreatedEventDTO>(contractAddress);
                var filterAllTransferEventsForContract = transferEventHandler.CreateFilterInput();
                var filterPeriodic = await transferEventHandler.CreateFilterAsync(filterAllTransferEventsForContract);
                var presaleCreated = await transferEventHandler.GetFilterChangesAsync(filterPeriodic);
                for (int i = 0; i < presaleCreated.Count; i++)
                {
                    BigInteger item = presaleCreated[i].Event.PresaleId;
                    await GetPresale(web3, item);
                }
            }
            //Do your cleanup (e.g. Stop code) here
        }

        private static async Task GetPresale(Web3 web3, BigInteger item)
        {
            var presaleFunction = new PresalesFunction() { ReturnValue1 = item };
            var presaleHandler = web3.Eth.GetContractQueryHandler<PresalesFunction>();
            var result = await presaleHandler.QueryAsync<PresalesOutputDTO>(contractAddress, presaleFunction);
            presales.Add(result.Id, result);
            Debug.WriteLine($"Presale id {result.Id}");
        }
    }
}
