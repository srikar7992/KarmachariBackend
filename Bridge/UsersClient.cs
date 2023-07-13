using AutoMapper;
using Karmchari.Data.Contracts;
using DataEntityModels;

namespace Bridge;

public class UsersClient : BaseBridgeClient<User, BusinessEntityModels.User>
{
    public UsersClient(IMapper mapper, IUserDataContract dataContract) : base(mapper, dataContract)
    {
    }
}
