using Bridge;
using BusinessEntityModels;
using Karmachari.Business.Contracts.Users;

namespace Karmchari.Business.Services.Users;

public class UserServices : BusinessServiceBase<User, DataEntityModels.User>, IUserBusinessContract
{
    public UserServices(UsersClient bridgeClient) : base(bridgeClient)
    {
    }
}
