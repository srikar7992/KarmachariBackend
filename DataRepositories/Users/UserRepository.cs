using DataEntityModels;
using EntityDbContext;
using Karmchari.Data.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Karmchari.Data.Repositories;

public class UserRepository : DataRepositoryBase<User>, IUserDataContract
{
    public UserRepository(KarmachariDbContext context) : base(context)
    {
    }
}
