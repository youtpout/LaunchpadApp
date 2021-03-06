using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace LaunchpadContract.Contracts.Launchpad.ContractDefinition
{


    public partial class LaunchpadDeployment : LaunchpadDeploymentBase
    {
        public LaunchpadDeployment() : base(BYTECODE) { }
        public LaunchpadDeployment(string byteCode) : base(byteCode) { }
    }

    public class LaunchpadDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "60806040523480156200001157600080fd5b506200001f60003362000051565b6200004b7f71f3d55856e4058ed06ee057d79ada615f65cdf5f9ee88181b914225088f834f3362000051565b620001b6565b6200005d828262000061565b5050565b620000788282620000a460201b62000f1b1760201c565b60008281526001602090815260409091206200009f91839062000f9f62000144821b17901c565b505050565b6000828152602081815260408083206001600160a01b038516845290915290205460ff166200005d576000828152602081815260408083206001600160a01b03851684529091529020805460ff19166001179055620001003390565b6001600160a01b0316816001600160a01b0316837f2f8788117e7eff1d82e926ec794901d17c78024a50270940304540a733656f0d60405160405180910390a45050565b60006200015b836001600160a01b03841662000164565b90505b92915050565b6000818152600183016020526040812054620001ad575081546001818101845560008481526020808220909301849055845484825282860190935260409020919091556200015e565b5060006200015e565b61189280620001c66000396000f3fe608060405234801561001057600080fd5b50600436106101165760003560e01c80639010d07c116100a2578063ca15c87311610071578063ca15c87314610276578063d18c891714610289578063d547741f1461029c578063f1cf03b6146102af578063ff495811146102c257600080fd5b80639010d07c1461022857806391d1485414610253578063a17e8e0914610266578063a217fddf1461026e57600080fd5b80635c4d4164116100e95780635c4d41641461019c57806378db0c14146101af578063797669c9146101c25780637dbfb36d146101e957806382760cd21461021557600080fd5b806301ffc9a71461011b578063248a9ca3146101435780632f2ff15d1461017457806336568abe14610189575b600080fd5b61012e6101293660046114b3565b6102d5565b60405190151581526020015b60405180910390f35b6101666101513660046114dd565b60009081526020819052604090206001015490565b60405190815260200161013a565b61018761018236600461150e565b610300565b005b61018761019736600461150e565b61032b565b6101876101aa3660046114dd565b6103ae565b6101876101bd3660046114dd565b6104b4565b6101667f71f3d55856e4058ed06ee057d79ada615f65cdf5f9ee88181b914225088f834f81565b6101fc6101f73660046114dd565b6105e5565b60405161013a9d9c9b9a99989796959493929190611554565b6101876102233660046115e9565b61066d565b61023b6102363660046115e9565b61078d565b6040516001600160a01b03909116815260200161013a565b61012e61026136600461150e565b6107ac565b600254610166565b610166600081565b6101666102843660046114dd565b6107d5565b6101876102973660046114dd565b6107ec565b6101876102aa36600461150e565b610a00565b6101876102bd36600461160b565b610a26565b6101666102d0366004611660565b610eea565b60006001600160e01b03198216635a05180f60e01b14806102fa57506102fa82610fb4565b92915050565b60008281526020819052604090206001015461031c8133610fe9565b610326838361104d565b505050565b6001600160a01b03811633146103a05760405162461bcd60e51b815260206004820152602f60248201527f416363657373436f6e74726f6c3a2063616e206f6e6c792072656e6f756e636560448201526e103937b632b9903337b91039b2b63360891b60648201526084015b60405180910390fd5b6103aa828261106f565b5050565b7f71f3d55856e4058ed06ee057d79ada615f65cdf5f9ee88181b914225088f834f6103d98133610fe9565b6003600283815481106103ee576103ee61168c565b60009182526020909120600c600d90920201015460ff1660048111156104165761041661153e565b141561043557604051636b37774b60e11b815260040160405180910390fd5b60016002838154811061044a5761044a61168c565b60009182526020909120600c600d9092020101805460ff191660018360048111156104775761047761153e565b02179055506040518281527f4baefdbb3caf36b29c6bc643404eb8a70c9999f90949e0acd439f2aba6d5e05b906020015b60405180910390a15050565b336001600160a01b0316600282815481106104d1576104d161168c565b600091825260209091206004600d9092020101546001600160a01b03161461050c5760405163251c9d6360e01b815260040160405180910390fd5b6003600282815481106105215761052161168c565b60009182526020909120600c600d90920201015460ff1660048111156105495761054961153e565b141561056857604051636b37774b60e11b815260040160405180910390fd5b60016002828154811061057d5761057d61168c565b60009182526020909120600c600d9092020101805460ff191660018360048111156105aa576105aa61153e565b02179055506040518181527f4baefdbb3caf36b29c6bc643404eb8a70c9999f90949e0acd439f2aba6d5e05b9060200160405180910390a150565b600281815481106105f557600080fd5b60009182526020909120600d9091020180546001820154600283015460038401546004850154600586015460068701546007880154600889015460098a0154600a8b0154600b8c0154600c909c01549a9c506001600160a01b03998a169b989a97999096169794969395929491939092919060ff168d565b336001600160a01b03166002838154811061068a5761068a61168c565b600091825260209091206004600d9092020101546001600160a01b0316146106c55760405163251c9d6360e01b815260040160405180910390fd5b42600283815481106106d9576106d961168c565b90600052602060002090600d02016007018190555080600283815481106107025761070261168c565b90600052602060002090600d020160080181905550600280838154811061072b5761072b61168c565b60009182526020909120600c600d9092020101805460ff191660018360048111156107585761075861153e565b02179055506040518281527f6f1ff997921b176499b9d243542606044c71ea9d55310d8c2f6544cfde1b182e906020016104a8565b60008281526001602052604081206107a59083611091565b9392505050565b6000918252602082815260408084206001600160a01b0393909316845291905290205460ff1690565b60008181526001602052604081206102fa9061109d565b7f71f3d55856e4058ed06ee057d79ada615f65cdf5f9ee88181b914225088f834f6108178133610fe9565b600280838154811061082b5761082b61168c565b60009182526020909120600c600d90920201015460ff1660048111156108535761085361153e565b1461087157604051639f80cef560e01b815260040160405180910390fd5b42600283815481106108855761088561168c565b90600052602060002090600d02016008015410156108b657604051630d5c2cd960e41b815260040160405180910390fd5b600282815481106108c9576108c961168c565b90600052602060002090600d020160090154600283815481106108ee576108ee61168c565b90600052602060002090600d0201600b015410156109835760046002838154811061091b5761091b61168c565b60009182526020909120600c600d9092020101805460ff191660018360048111156109485761094861153e565b021790555060408051838152600060208201527f4249fbb50b98c1e93c8feff8d0f79b0a33effdda740ab62eb06bc0138fe9756891016104a8565b6003600283815481106109985761099861168c565b60009182526020909120600c600d9092020101805460ff191660018360048111156109c5576109c561153e565b021790555060408051838152600160208201527f4249fbb50b98c1e93c8feff8d0f79b0a33effdda740ab62eb06bc0138fe9756891016104a8565b600082815260208190526040902060010154610a1c8133610fe9565b610326838361106f565b604051636eb1769f60e11b81523360048201523060248201526000906001600160a01b0389169063dd62ed3e90604401602060405180830381865afa158015610a73573d6000803e3d6000fd5b505050506040513d601f19601f82011682018060405250810190610a9791906116a2565b905086811015610abd5760405163a346aca960e01b815260048101829052602401610397565b60405163a9059cbb60e01b8152306004820152602481018890526001600160a01b0389169063a9059cbb906044016020604051808303816000875af1158015610b0a573d6000803e3d6000fd5b505050506040513d601f19601f82011682018060405250810190610b2e91906116bb565b506040516370a0823160e01b81523060048201526000906001600160a01b038a16906370a0823190602401602060405180830381865afa158015610b76573d6000803e3d6000fd5b505050506040513d601f19601f82011682018060405250810190610b9a91906116a2565b905087811015610bc057604051637d62714d60e11b815260048101829052602401610397565b610bc8611429565b600280548083526001600160a01b038c811660208501908152604085018d8152606086018d815260a087018d815260c088018d815261012089018d81526101408a018d81523360808c0190815260006101808d018181526001808d018e559c9091528c51600d909b027f405787fa12a823e0f2b7631cc41b3ba8828b3321ca811111fa75cd3aa3bb5ace81019b8c5598517f405787fa12a823e0f2b7631cc41b3ba8828b3321ca811111fa75cd3aa3bb5acf8a018054918c166001600160a01b031992831617905597517f405787fa12a823e0f2b7631cc41b3ba8828b3321ca811111fa75cd3aa3bb5ad08a015595517f405787fa12a823e0f2b7631cc41b3ba8828b3321ca811111fa75cd3aa3bb5ad1890155517f405787fa12a823e0f2b7631cc41b3ba8828b3321ca811111fa75cd3aa3bb5ad2880180549190991696169590951790965590517f405787fa12a823e0f2b7631cc41b3ba8828b3321ca811111fa75cd3aa3bb5ad3850155517f405787fa12a823e0f2b7631cc41b3ba8828b3321ca811111fa75cd3aa3bb5ad484015560e08701517f405787fa12a823e0f2b7631cc41b3ba8828b3321ca811111fa75cd3aa3bb5ad58401556101008701517f405787fa12a823e0f2b7631cc41b3ba8828b3321ca811111fa75cd3aa3bb5ad684015592517f405787fa12a823e0f2b7631cc41b3ba8828b3321ca811111fa75cd3aa3bb5ad7830155517f405787fa12a823e0f2b7631cc41b3ba8828b3321ca811111fa75cd3aa3bb5ad88201556101608501517f405787fa12a823e0f2b7631cc41b3ba8828b3321ca811111fa75cd3aa3bb5ad982015590517f405787fa12a823e0f2b7631cc41b3ba8828b3321ca811111fa75cd3aa3bb5ada9091018054859460ff199190911690836004811115610e6657610e6661153e565b02179055505033600081815260036020908152604080832086518154600181018355918552938390200192909255845182519384526001600160a01b038f1691840191909152908201527f0e4504e16dbcbcc2f86335dd994a981b1dd426132c981d112a8eb5220655bbed915060600160405180910390a150505050505050505050565b60036020528160005260406000208181548110610f0657600080fd5b90600052602060002001600091509150505481565b610f2582826107ac565b6103aa576000828152602081815260408083206001600160a01b03851684529091529020805460ff19166001179055610f5b3390565b6001600160a01b0316816001600160a01b0316837f2f8788117e7eff1d82e926ec794901d17c78024a50270940304540a733656f0d60405160405180910390a45050565b60006107a5836001600160a01b0384166110a7565b60006001600160e01b03198216637965db0b60e01b14806102fa57506301ffc9a760e01b6001600160e01b03198316146102fa565b610ff382826107ac565b6103aa5761100b816001600160a01b031660146110f6565b6110168360206110f6565b60405160200161102792919061170d565b60408051601f198184030181529082905262461bcd60e51b825261039791600401611782565b6110578282610f1b565b60008281526001602052604090206103269082610f9f565b6110798282611292565b600082815260016020526040902061032690826112f7565b60006107a5838361130c565b60006102fa825490565b60008181526001830160205260408120546110ee575081546001818101845560008481526020808220909301849055845484825282860190935260409020919091556102fa565b5060006102fa565b606060006111058360026117cb565b6111109060026117ea565b67ffffffffffffffff81111561112857611128611802565b6040519080825280601f01601f191660200182016040528015611152576020820181803683370190505b509050600360fc1b8160008151811061116d5761116d61168c565b60200101906001600160f81b031916908160001a905350600f60fb1b8160018151811061119c5761119c61168c565b60200101906001600160f81b031916908160001a90535060006111c08460026117cb565b6111cb9060016117ea565b90505b6001811115611243576f181899199a1a9b1b9c1cb0b131b232b360811b85600f16601081106111ff576111ff61168c565b1a60f81b8282815181106112155761121561168c565b60200101906001600160f81b031916908160001a90535060049490941c9361123c81611818565b90506111ce565b5083156107a55760405162461bcd60e51b815260206004820181905260248201527f537472696e67733a20686578206c656e67746820696e73756666696369656e746044820152606401610397565b61129c82826107ac565b156103aa576000828152602081815260408083206001600160a01b0385168085529252808320805460ff1916905551339285917ff6391f5c32d9c69d2a47ea670b442974b53935d1edc7fd64eb21e047a839171b9190a45050565b60006107a5836001600160a01b038416611336565b60008260000182815481106113235761132361168c565b9060005260206000200154905092915050565b6000818152600183016020526040812054801561141f57600061135a60018361182f565b855490915060009061136e9060019061182f565b90508181146113d357600086600001828154811061138e5761138e61168c565b90600052602060002001549050808760000184815481106113b1576113b161168c565b6000918252602080832090910192909255918252600188019052604090208390555b85548690806113e4576113e4611846565b6001900381819060005260206000200160009055905585600101600086815260200190815260200160002060009055600193505050506102fa565b60009150506102fa565b604051806101a001604052806000815260200160006001600160a01b03168152602001600081526020016000815260200160006001600160a01b0316815260200160008152602001600081526020016000815260200160008152602001600081526020016000815260200160008152602001600060048111156114ae576114ae61153e565b905290565b6000602082840312156114c557600080fd5b81356001600160e01b0319811681146107a557600080fd5b6000602082840312156114ef57600080fd5b5035919050565b6001600160a01b038116811461150b57600080fd5b50565b6000806040838503121561152157600080fd5b823591506020830135611533816114f6565b809150509250929050565b634e487b7160e01b600052602160045260246000fd5b60006101a0820190508e825260018060a01b03808f1660208401528d60408401528c6060840152808c166080840152508960a08301528860c08301528760e083015286610100830152856101208301528461014083015283610160830152600583106115d057634e487b7160e01b600052602160045260246000fd5b826101808301529e9d5050505050505050505050505050565b600080604083850312156115fc57600080fd5b50508035926020909101359150565b600080600080600080600060e0888a03121561162657600080fd5b8735611631816114f6565b9960208901359950604089013598606081013598506080810135975060a0810135965060c00135945092505050565b6000806040838503121561167357600080fd5b823561167e816114f6565b946020939093013593505050565b634e487b7160e01b600052603260045260246000fd5b6000602082840312156116b457600080fd5b5051919050565b6000602082840312156116cd57600080fd5b815180151581146107a557600080fd5b60005b838110156116f85781810151838201526020016116e0565b83811115611707576000848401525b50505050565b7f416363657373436f6e74726f6c3a206163636f756e74200000000000000000008152600083516117458160178501602088016116dd565b7001034b99036b4b9b9b4b733903937b6329607d1b60179184019182015283516117768160288401602088016116dd565b01602801949350505050565b60208152600082518060208401526117a18160408501602087016116dd565b601f01601f19169190910160400192915050565b634e487b7160e01b600052601160045260246000fd5b60008160001904831182151516156117e5576117e56117b5565b500290565b600082198211156117fd576117fd6117b5565b500190565b634e487b7160e01b600052604160045260246000fd5b600081611827576118276117b5565b506000190190565b600082821015611841576118416117b5565b500390565b634e487b7160e01b600052603160045260246000fdfea264697066735822122080fbd5d39dbe89b6c2c71db13cfc854d3a88925ac6d050a2901813c1ee58f69464736f6c634300080b0033";
        public LaunchpadDeploymentBase() : base(BYTECODE) { }
        public LaunchpadDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class DEFAULT_ADMIN_ROLEFunction : DEFAULT_ADMIN_ROLEFunctionBase { }

    [Function("DEFAULT_ADMIN_ROLE", "bytes32")]
    public class DEFAULT_ADMIN_ROLEFunctionBase : FunctionMessage
    {

    }

    public partial class MODERATOR_ROLEFunction : MODERATOR_ROLEFunctionBase { }

    [Function("MODERATOR_ROLE", "bytes32")]
    public class MODERATOR_ROLEFunctionBase : FunctionMessage
    {

    }

    public partial class CanceledFunction : CanceledFunctionBase { }

    [Function("canceled")]
    public class CanceledFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "id", 1)]
        public virtual BigInteger Id { get; set; }
    }

    public partial class CreatePresaleFunction : CreatePresaleFunctionBase { }

    [Function("createPresale")]
    public class CreatePresaleFunctionBase : FunctionMessage
    {
        [Parameter("address", "token", 1)]
        public virtual string Token { get; set; }
        [Parameter("uint256", "tokenAmount", 2)]
        public virtual BigInteger TokenAmount { get; set; }
        [Parameter("uint256", "tokenByBNB", 3)]
        public virtual BigInteger TokenByBNB { get; set; }
        [Parameter("uint256", "amountMin", 4)]
        public virtual BigInteger AmountMin { get; set; }
        [Parameter("uint256", "amountMax", 5)]
        public virtual BigInteger AmountMax { get; set; }
        [Parameter("uint256", "softCap", 6)]
        public virtual BigInteger SoftCap { get; set; }
        [Parameter("uint256", "hardCap", 7)]
        public virtual BigInteger HardCap { get; set; }
    }

    public partial class FinishedFunction : FinishedFunctionBase { }

    [Function("finished")]
    public class FinishedFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "id", 1)]
        public virtual BigInteger Id { get; set; }
    }

    public partial class GetRoleAdminFunction : GetRoleAdminFunctionBase { }

    [Function("getRoleAdmin", "bytes32")]
    public class GetRoleAdminFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "role", 1)]
        public virtual byte[] Role { get; set; }
    }

    public partial class GetRoleMemberFunction : GetRoleMemberFunctionBase { }

    [Function("getRoleMember", "address")]
    public class GetRoleMemberFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "role", 1)]
        public virtual byte[] Role { get; set; }
        [Parameter("uint256", "index", 2)]
        public virtual BigInteger Index { get; set; }
    }

    public partial class GetRoleMemberCountFunction : GetRoleMemberCountFunctionBase { }

    [Function("getRoleMemberCount", "uint256")]
    public class GetRoleMemberCountFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "role", 1)]
        public virtual byte[] Role { get; set; }
    }

    public partial class GrantRoleFunction : GrantRoleFunctionBase { }

    [Function("grantRole")]
    public class GrantRoleFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "role", 1)]
        public virtual byte[] Role { get; set; }
        [Parameter("address", "account", 2)]
        public virtual string Account { get; set; }
    }

    public partial class HasRoleFunction : HasRoleFunctionBase { }

    [Function("hasRole", "bool")]
    public class HasRoleFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "role", 1)]
        public virtual byte[] Role { get; set; }
        [Parameter("address", "account", 2)]
        public virtual string Account { get; set; }
    }

    public partial class LaunchFunction : LaunchFunctionBase { }

    [Function("launch")]
    public class LaunchFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "id", 1)]
        public virtual BigInteger Id { get; set; }
        [Parameter("uint256", "endDate", 2)]
        public virtual BigInteger EndDate { get; set; }
    }

    public partial class ModeratorCancelFunction : ModeratorCancelFunctionBase { }

    [Function("moderatorCancel")]
    public class ModeratorCancelFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "id", 1)]
        public virtual BigInteger Id { get; set; }
    }

    public partial class PresalesFunction : PresalesFunctionBase { }

    [Function("presales", typeof(PresalesOutputDTO))]
    public class PresalesFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class PresalesCountFunction : PresalesCountFunctionBase { }

    [Function("presalesCount", "uint256")]
    public class PresalesCountFunctionBase : FunctionMessage
    {

    }

    public partial class RenounceRoleFunction : RenounceRoleFunctionBase { }

    [Function("renounceRole")]
    public class RenounceRoleFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "role", 1)]
        public virtual byte[] Role { get; set; }
        [Parameter("address", "account", 2)]
        public virtual string Account { get; set; }
    }

    public partial class RevokeRoleFunction : RevokeRoleFunctionBase { }

    [Function("revokeRole")]
    public class RevokeRoleFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "role", 1)]
        public virtual byte[] Role { get; set; }
        [Parameter("address", "account", 2)]
        public virtual string Account { get; set; }
    }

    public partial class SupportsInterfaceFunction : SupportsInterfaceFunctionBase { }

    [Function("supportsInterface", "bool")]
    public class SupportsInterfaceFunctionBase : FunctionMessage
    {
        [Parameter("bytes4", "interfaceId", 1)]
        public virtual byte[] InterfaceId { get; set; }
    }

    public partial class UserPresalesFunction : UserPresalesFunctionBase { }

    [Function("userPresales", "uint256")]
    public class UserPresalesFunctionBase : FunctionMessage
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
        [Parameter("uint256", "", 2)]
        public virtual BigInteger ReturnValue2 { get; set; }
    }

    public partial class PresaleCanceledEventDTO : PresaleCanceledEventDTOBase { }

    [Event("PresaleCanceled")]
    public class PresaleCanceledEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "presaleId", 1, false )]
        public virtual BigInteger PresaleId { get; set; }
    }

    public partial class PresaleCreatedEventDTO : PresaleCreatedEventDTOBase { }

    [Event("PresaleCreated")]
    public class PresaleCreatedEventDTOBase : IEventDTO
    {
        [Parameter("address", "owner", 1, false )]
        public virtual string Owner { get; set; }
        [Parameter("address", "token", 2, false )]
        public virtual string Token { get; set; }
        [Parameter("uint256", "presaleId", 3, false )]
        public virtual BigInteger PresaleId { get; set; }
    }

    public partial class PresaleFinishedEventDTO : PresaleFinishedEventDTOBase { }

    [Event("PresaleFinished")]
    public class PresaleFinishedEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "presaleId", 1, false )]
        public virtual BigInteger PresaleId { get; set; }
        [Parameter("bool", "filled", 2, false )]
        public virtual bool Filled { get; set; }
    }

    public partial class PresaleLaunchedEventDTO : PresaleLaunchedEventDTOBase { }

    [Event("PresaleLaunched")]
    public class PresaleLaunchedEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "presaleId", 1, false )]
        public virtual BigInteger PresaleId { get; set; }
    }

    public partial class RoleAdminChangedEventDTO : RoleAdminChangedEventDTOBase { }

    [Event("RoleAdminChanged")]
    public class RoleAdminChangedEventDTOBase : IEventDTO
    {
        [Parameter("bytes32", "role", 1, true )]
        public virtual byte[] Role { get; set; }
        [Parameter("bytes32", "previousAdminRole", 2, true )]
        public virtual byte[] PreviousAdminRole { get; set; }
        [Parameter("bytes32", "newAdminRole", 3, true )]
        public virtual byte[] NewAdminRole { get; set; }
    }

    public partial class RoleGrantedEventDTO : RoleGrantedEventDTOBase { }

    [Event("RoleGranted")]
    public class RoleGrantedEventDTOBase : IEventDTO
    {
        [Parameter("bytes32", "role", 1, true )]
        public virtual byte[] Role { get; set; }
        [Parameter("address", "account", 2, true )]
        public virtual string Account { get; set; }
        [Parameter("address", "sender", 3, true )]
        public virtual string Sender { get; set; }
    }

    public partial class RoleRevokedEventDTO : RoleRevokedEventDTOBase { }

    [Event("RoleRevoked")]
    public class RoleRevokedEventDTOBase : IEventDTO
    {
        [Parameter("bytes32", "role", 1, true )]
        public virtual byte[] Role { get; set; }
        [Parameter("address", "account", 2, true )]
        public virtual string Account { get; set; }
        [Parameter("address", "sender", 3, true )]
        public virtual string Sender { get; set; }
    }







    public partial class TokenIncorrectAmountError : TokenIncorrectAmountErrorBase { }

    [Error("tokenIncorrectAmount")]
    public class TokenIncorrectAmountErrorBase : IErrorDTO
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class TokenNotApprovedError : TokenNotApprovedErrorBase { }

    [Error("tokenNotApproved")]
    public class TokenNotApprovedErrorBase : IErrorDTO
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }



    public partial class DEFAULT_ADMIN_ROLEOutputDTO : DEFAULT_ADMIN_ROLEOutputDTOBase { }

    [FunctionOutput]
    public class DEFAULT_ADMIN_ROLEOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class MODERATOR_ROLEOutputDTO : MODERATOR_ROLEOutputDTOBase { }

    [FunctionOutput]
    public class MODERATOR_ROLEOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }







    public partial class GetRoleAdminOutputDTO : GetRoleAdminOutputDTOBase { }

    [FunctionOutput]
    public class GetRoleAdminOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class GetRoleMemberOutputDTO : GetRoleMemberOutputDTOBase { }

    [FunctionOutput]
    public class GetRoleMemberOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class GetRoleMemberCountOutputDTO : GetRoleMemberCountOutputDTOBase { }

    [FunctionOutput]
    public class GetRoleMemberCountOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }



    public partial class HasRoleOutputDTO : HasRoleOutputDTOBase { }

    [FunctionOutput]
    public class HasRoleOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }





    public partial class PresalesOutputDTO : PresalesOutputDTOBase { }

    [FunctionOutput]
    public class PresalesOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "id", 1)]
        public virtual BigInteger Id { get; set; }
        [Parameter("address", "tokenAddress", 2)]
        public virtual string TokenAddress { get; set; }
        [Parameter("uint256", "tokenAmount", 3)]
        public virtual BigInteger TokenAmount { get; set; }
        [Parameter("uint256", "tokenByBNB", 4)]
        public virtual BigInteger TokenByBNB { get; set; }
        [Parameter("address", "owner", 5)]
        public virtual string Owner { get; set; }
        [Parameter("uint256", "amountMin", 6)]
        public virtual BigInteger AmountMin { get; set; }
        [Parameter("uint256", "amountMax", 7)]
        public virtual BigInteger AmountMax { get; set; }
        [Parameter("uint256", "startDate", 8)]
        public virtual BigInteger StartDate { get; set; }
        [Parameter("uint256", "endDate", 9)]
        public virtual BigInteger EndDate { get; set; }
        [Parameter("uint256", "softCap", 10)]
        public virtual BigInteger SoftCap { get; set; }
        [Parameter("uint256", "hardCap", 11)]
        public virtual BigInteger HardCap { get; set; }
        [Parameter("uint256", "actualCap", 12)]
        public virtual BigInteger ActualCap { get; set; }
        [Parameter("uint8", "status", 13)]
        public virtual byte Status { get; set; }
    }

    public partial class PresalesCountOutputDTO : PresalesCountOutputDTOBase { }

    [FunctionOutput]
    public class PresalesCountOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }





    public partial class SupportsInterfaceOutputDTO : SupportsInterfaceOutputDTOBase { }

    [FunctionOutput]
    public class SupportsInterfaceOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class UserPresalesOutputDTO : UserPresalesOutputDTOBase { }

    [FunctionOutput]
    public class UserPresalesOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }
}
