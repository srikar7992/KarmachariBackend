using Bridge;
using BusinessContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices;

public class BusinessServiceBase<TModel, TEntity> : IBaseBusinessContract<TModel>
    where TModel : class
    where TEntity : class
{
    private protected readonly BaseBridgeClient<TEntity, TModel> bridgeClient;

    public BusinessServiceBase(BaseBridgeClient<TEntity, TModel> bridgeClient)
    {
        this.bridgeClient = bridgeClient;
    }

    public void Add(TModel model)
    {
        bridgeClient.Add(model);
    }

    public void Delete(TModel model)
    {
        bridgeClient.Delete(model);
    }

    public IQueryable<TModel> Find(Expression<Func<TModel, bool>> predicate)
    {
        return bridgeClient.Find(predicate);
    }

    public IEnumerable<TModel> GetAll()
    {
        return bridgeClient.GetAll();
    }

    public TModel GetById(Guid id)
    {
        return bridgeClient.GetById(id);
    }

    public void Update(TModel model)
    {
        bridgeClient.Update(model);
    }
}
