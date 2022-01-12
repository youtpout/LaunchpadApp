using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using LaunchpadContract.Contracts.Launchpad.ContractDefinition;

namespace LaunchpadContract.Contracts.Launchpad
{
    public partial class LaunchpadService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, LaunchpadDeployment launchpadDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<LaunchpadDeployment>().SendRequestAndWaitForReceiptAsync(launchpadDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, LaunchpadDeployment launchpadDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<LaunchpadDeployment>().SendRequestAsync(launchpadDeployment);
        }

        public static async Task<LaunchpadService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, LaunchpadDeployment launchpadDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, launchpadDeployment, cancellationTokenSource);
            return new LaunchpadService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public LaunchpadService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<byte[]> DEFAULT_ADMIN_ROLEQueryAsync(DEFAULT_ADMIN_ROLEFunction dEFAULT_ADMIN_ROLEFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DEFAULT_ADMIN_ROLEFunction, byte[]>(dEFAULT_ADMIN_ROLEFunction, blockParameter);
        }

        
        public Task<byte[]> DEFAULT_ADMIN_ROLEQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DEFAULT_ADMIN_ROLEFunction, byte[]>(null, blockParameter);
        }

        public Task<byte[]> MODERATOR_ROLEQueryAsync(MODERATOR_ROLEFunction mODERATOR_ROLEFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MODERATOR_ROLEFunction, byte[]>(mODERATOR_ROLEFunction, blockParameter);
        }

        
        public Task<byte[]> MODERATOR_ROLEQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MODERATOR_ROLEFunction, byte[]>(null, blockParameter);
        }

        public Task<string> CanceledRequestAsync(CanceledFunction canceledFunction)
        {
             return ContractHandler.SendRequestAsync(canceledFunction);
        }

        public Task<TransactionReceipt> CanceledRequestAndWaitForReceiptAsync(CanceledFunction canceledFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(canceledFunction, cancellationToken);
        }

        public Task<string> CanceledRequestAsync(BigInteger id)
        {
            var canceledFunction = new CanceledFunction();
                canceledFunction.Id = id;
            
             return ContractHandler.SendRequestAsync(canceledFunction);
        }

        public Task<TransactionReceipt> CanceledRequestAndWaitForReceiptAsync(BigInteger id, CancellationTokenSource cancellationToken = null)
        {
            var canceledFunction = new CanceledFunction();
                canceledFunction.Id = id;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(canceledFunction, cancellationToken);
        }

        public Task<string> CreatePresaleRequestAsync(CreatePresaleFunction createPresaleFunction)
        {
             return ContractHandler.SendRequestAsync(createPresaleFunction);
        }

        public Task<TransactionReceipt> CreatePresaleRequestAndWaitForReceiptAsync(CreatePresaleFunction createPresaleFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createPresaleFunction, cancellationToken);
        }

        public Task<string> CreatePresaleRequestAsync(string token, BigInteger tokenAmount, BigInteger tokenByBNB, BigInteger amountMin, BigInteger amountMax, BigInteger softCap, BigInteger hardCap)
        {
            var createPresaleFunction = new CreatePresaleFunction();
                createPresaleFunction.Token = token;
                createPresaleFunction.TokenAmount = tokenAmount;
                createPresaleFunction.TokenByBNB = tokenByBNB;
                createPresaleFunction.AmountMin = amountMin;
                createPresaleFunction.AmountMax = amountMax;
                createPresaleFunction.SoftCap = softCap;
                createPresaleFunction.HardCap = hardCap;
            
             return ContractHandler.SendRequestAsync(createPresaleFunction);
        }

        public Task<TransactionReceipt> CreatePresaleRequestAndWaitForReceiptAsync(string token, BigInteger tokenAmount, BigInteger tokenByBNB, BigInteger amountMin, BigInteger amountMax, BigInteger softCap, BigInteger hardCap, CancellationTokenSource cancellationToken = null)
        {
            var createPresaleFunction = new CreatePresaleFunction();
                createPresaleFunction.Token = token;
                createPresaleFunction.TokenAmount = tokenAmount;
                createPresaleFunction.TokenByBNB = tokenByBNB;
                createPresaleFunction.AmountMin = amountMin;
                createPresaleFunction.AmountMax = amountMax;
                createPresaleFunction.SoftCap = softCap;
                createPresaleFunction.HardCap = hardCap;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createPresaleFunction, cancellationToken);
        }

        public Task<string> FinishedRequestAsync(FinishedFunction finishedFunction)
        {
             return ContractHandler.SendRequestAsync(finishedFunction);
        }

        public Task<TransactionReceipt> FinishedRequestAndWaitForReceiptAsync(FinishedFunction finishedFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(finishedFunction, cancellationToken);
        }

        public Task<string> FinishedRequestAsync(BigInteger id)
        {
            var finishedFunction = new FinishedFunction();
                finishedFunction.Id = id;
            
             return ContractHandler.SendRequestAsync(finishedFunction);
        }

        public Task<TransactionReceipt> FinishedRequestAndWaitForReceiptAsync(BigInteger id, CancellationTokenSource cancellationToken = null)
        {
            var finishedFunction = new FinishedFunction();
                finishedFunction.Id = id;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(finishedFunction, cancellationToken);
        }

        public Task<byte[]> GetRoleAdminQueryAsync(GetRoleAdminFunction getRoleAdminFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetRoleAdminFunction, byte[]>(getRoleAdminFunction, blockParameter);
        }

        
        public Task<byte[]> GetRoleAdminQueryAsync(byte[] role, BlockParameter blockParameter = null)
        {
            var getRoleAdminFunction = new GetRoleAdminFunction();
                getRoleAdminFunction.Role = role;
            
            return ContractHandler.QueryAsync<GetRoleAdminFunction, byte[]>(getRoleAdminFunction, blockParameter);
        }

        public Task<string> GetRoleMemberQueryAsync(GetRoleMemberFunction getRoleMemberFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetRoleMemberFunction, string>(getRoleMemberFunction, blockParameter);
        }

        
        public Task<string> GetRoleMemberQueryAsync(byte[] role, BigInteger index, BlockParameter blockParameter = null)
        {
            var getRoleMemberFunction = new GetRoleMemberFunction();
                getRoleMemberFunction.Role = role;
                getRoleMemberFunction.Index = index;
            
            return ContractHandler.QueryAsync<GetRoleMemberFunction, string>(getRoleMemberFunction, blockParameter);
        }

        public Task<BigInteger> GetRoleMemberCountQueryAsync(GetRoleMemberCountFunction getRoleMemberCountFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetRoleMemberCountFunction, BigInteger>(getRoleMemberCountFunction, blockParameter);
        }

        
        public Task<BigInteger> GetRoleMemberCountQueryAsync(byte[] role, BlockParameter blockParameter = null)
        {
            var getRoleMemberCountFunction = new GetRoleMemberCountFunction();
                getRoleMemberCountFunction.Role = role;
            
            return ContractHandler.QueryAsync<GetRoleMemberCountFunction, BigInteger>(getRoleMemberCountFunction, blockParameter);
        }

        public Task<string> GrantRoleRequestAsync(GrantRoleFunction grantRoleFunction)
        {
             return ContractHandler.SendRequestAsync(grantRoleFunction);
        }

        public Task<TransactionReceipt> GrantRoleRequestAndWaitForReceiptAsync(GrantRoleFunction grantRoleFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(grantRoleFunction, cancellationToken);
        }

        public Task<string> GrantRoleRequestAsync(byte[] role, string account)
        {
            var grantRoleFunction = new GrantRoleFunction();
                grantRoleFunction.Role = role;
                grantRoleFunction.Account = account;
            
             return ContractHandler.SendRequestAsync(grantRoleFunction);
        }

        public Task<TransactionReceipt> GrantRoleRequestAndWaitForReceiptAsync(byte[] role, string account, CancellationTokenSource cancellationToken = null)
        {
            var grantRoleFunction = new GrantRoleFunction();
                grantRoleFunction.Role = role;
                grantRoleFunction.Account = account;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(grantRoleFunction, cancellationToken);
        }

        public Task<bool> HasRoleQueryAsync(HasRoleFunction hasRoleFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<HasRoleFunction, bool>(hasRoleFunction, blockParameter);
        }

        
        public Task<bool> HasRoleQueryAsync(byte[] role, string account, BlockParameter blockParameter = null)
        {
            var hasRoleFunction = new HasRoleFunction();
                hasRoleFunction.Role = role;
                hasRoleFunction.Account = account;
            
            return ContractHandler.QueryAsync<HasRoleFunction, bool>(hasRoleFunction, blockParameter);
        }

        public Task<string> LaunchRequestAsync(LaunchFunction launchFunction)
        {
             return ContractHandler.SendRequestAsync(launchFunction);
        }

        public Task<TransactionReceipt> LaunchRequestAndWaitForReceiptAsync(LaunchFunction launchFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(launchFunction, cancellationToken);
        }

        public Task<string> LaunchRequestAsync(BigInteger id, BigInteger endDate)
        {
            var launchFunction = new LaunchFunction();
                launchFunction.Id = id;
                launchFunction.EndDate = endDate;
            
             return ContractHandler.SendRequestAsync(launchFunction);
        }

        public Task<TransactionReceipt> LaunchRequestAndWaitForReceiptAsync(BigInteger id, BigInteger endDate, CancellationTokenSource cancellationToken = null)
        {
            var launchFunction = new LaunchFunction();
                launchFunction.Id = id;
                launchFunction.EndDate = endDate;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(launchFunction, cancellationToken);
        }

        public Task<string> ModeratorCancelRequestAsync(ModeratorCancelFunction moderatorCancelFunction)
        {
             return ContractHandler.SendRequestAsync(moderatorCancelFunction);
        }

        public Task<TransactionReceipt> ModeratorCancelRequestAndWaitForReceiptAsync(ModeratorCancelFunction moderatorCancelFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(moderatorCancelFunction, cancellationToken);
        }

        public Task<string> ModeratorCancelRequestAsync(BigInteger id)
        {
            var moderatorCancelFunction = new ModeratorCancelFunction();
                moderatorCancelFunction.Id = id;
            
             return ContractHandler.SendRequestAsync(moderatorCancelFunction);
        }

        public Task<TransactionReceipt> ModeratorCancelRequestAndWaitForReceiptAsync(BigInteger id, CancellationTokenSource cancellationToken = null)
        {
            var moderatorCancelFunction = new ModeratorCancelFunction();
                moderatorCancelFunction.Id = id;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(moderatorCancelFunction, cancellationToken);
        }

        public Task<PresalesOutputDTO> PresalesQueryAsync(PresalesFunction presalesFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<PresalesFunction, PresalesOutputDTO>(presalesFunction, blockParameter);
        }

        public Task<PresalesOutputDTO> PresalesQueryAsync(BigInteger returnValue1, BlockParameter blockParameter = null)
        {
            var presalesFunction = new PresalesFunction();
                presalesFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryDeserializingToObjectAsync<PresalesFunction, PresalesOutputDTO>(presalesFunction, blockParameter);
        }

        public Task<BigInteger> PresalesCountQueryAsync(PresalesCountFunction presalesCountFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PresalesCountFunction, BigInteger>(presalesCountFunction, blockParameter);
        }

        
        public Task<BigInteger> PresalesCountQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PresalesCountFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> RenounceRoleRequestAsync(RenounceRoleFunction renounceRoleFunction)
        {
             return ContractHandler.SendRequestAsync(renounceRoleFunction);
        }

        public Task<TransactionReceipt> RenounceRoleRequestAndWaitForReceiptAsync(RenounceRoleFunction renounceRoleFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(renounceRoleFunction, cancellationToken);
        }

        public Task<string> RenounceRoleRequestAsync(byte[] role, string account)
        {
            var renounceRoleFunction = new RenounceRoleFunction();
                renounceRoleFunction.Role = role;
                renounceRoleFunction.Account = account;
            
             return ContractHandler.SendRequestAsync(renounceRoleFunction);
        }

        public Task<TransactionReceipt> RenounceRoleRequestAndWaitForReceiptAsync(byte[] role, string account, CancellationTokenSource cancellationToken = null)
        {
            var renounceRoleFunction = new RenounceRoleFunction();
                renounceRoleFunction.Role = role;
                renounceRoleFunction.Account = account;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(renounceRoleFunction, cancellationToken);
        }

        public Task<string> RevokeRoleRequestAsync(RevokeRoleFunction revokeRoleFunction)
        {
             return ContractHandler.SendRequestAsync(revokeRoleFunction);
        }

        public Task<TransactionReceipt> RevokeRoleRequestAndWaitForReceiptAsync(RevokeRoleFunction revokeRoleFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(revokeRoleFunction, cancellationToken);
        }

        public Task<string> RevokeRoleRequestAsync(byte[] role, string account)
        {
            var revokeRoleFunction = new RevokeRoleFunction();
                revokeRoleFunction.Role = role;
                revokeRoleFunction.Account = account;
            
             return ContractHandler.SendRequestAsync(revokeRoleFunction);
        }

        public Task<TransactionReceipt> RevokeRoleRequestAndWaitForReceiptAsync(byte[] role, string account, CancellationTokenSource cancellationToken = null)
        {
            var revokeRoleFunction = new RevokeRoleFunction();
                revokeRoleFunction.Role = role;
                revokeRoleFunction.Account = account;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(revokeRoleFunction, cancellationToken);
        }

        public Task<bool> SupportsInterfaceQueryAsync(SupportsInterfaceFunction supportsInterfaceFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SupportsInterfaceFunction, bool>(supportsInterfaceFunction, blockParameter);
        }

        
        public Task<bool> SupportsInterfaceQueryAsync(byte[] interfaceId, BlockParameter blockParameter = null)
        {
            var supportsInterfaceFunction = new SupportsInterfaceFunction();
                supportsInterfaceFunction.InterfaceId = interfaceId;
            
            return ContractHandler.QueryAsync<SupportsInterfaceFunction, bool>(supportsInterfaceFunction, blockParameter);
        }

        public Task<BigInteger> UserPresalesQueryAsync(UserPresalesFunction userPresalesFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<UserPresalesFunction, BigInteger>(userPresalesFunction, blockParameter);
        }

        
        public Task<BigInteger> UserPresalesQueryAsync(string returnValue1, BigInteger returnValue2, BlockParameter blockParameter = null)
        {
            var userPresalesFunction = new UserPresalesFunction();
                userPresalesFunction.ReturnValue1 = returnValue1;
                userPresalesFunction.ReturnValue2 = returnValue2;
            
            return ContractHandler.QueryAsync<UserPresalesFunction, BigInteger>(userPresalesFunction, blockParameter);
        }
    }
}
