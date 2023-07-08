using DataContracts;
using DataEntityModels;
using Microsoft.EntityFrameworkCore;

namespace DataRepositories;

public class UserRepository : BaseDataRepository<User>, IUserDataContract
{
    public UserRepository(DbContext context) : base(context)
    {
    }
}
