using LaunchpadContract.Contracts.Launchpad.ContractDefinition;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace LaunchpadApp.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class BlockchainController : ControllerBase
    {
        // no database for the POC
        [HttpGet]
        public IEnumerable<PresalesOutputDTO> Get()
        {
            return PresaleService.presales.Values;
        }
    }
}
