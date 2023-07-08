using AutoMapper;
using DataContracts;
using System.Linq.Expressions;

namespace Bridge;

public class BaseBridgeClient<TEntity, TModel> 
    where TEntity : class
    where TModel : class
{
    private protected readonly IMapper _mapper;
    private protected readonly IBaseDataContract<TEntity> dataContract;

    public BaseBridgeClient(IMapper mapper, IBaseDataContract<TEntity> dataContract)
    {
        _mapper = mapper;
        this.dataContract = dataContract;
    }

    public void Add(TModel model)
    {
        var entity = _mapper.Map<TEntity>(model);
        dataContract.Add(entity);
    }

    public void Delete(TModel model)
    {
        var entity = _mapper.Map<TEntity>(model);
        dataContract.Delete(entity);    
    }

    public IQueryable<TModel> Find(Expression<Func<TModel, bool>> predicate)
    {
        var entityPredicate = _mapper.Map<Expression<Func<TEntity, bool>>>(predicate);
        var entities = dataContract.Find(entityPredicate);
        var results = _mapper.Map<IQueryable<TModel>>(entities);
        return results;
    }

    public IEnumerable<TModel> GetAll()
    {
        var data = dataContract.GetAll();
        var results = _mapper.Map<IEnumerable<TModel>>(data);
        return results;
    }

    public TModel GetById(Guid id)
    {
        var entity = dataContract.GetById(id);
        var result = _mapper.Map<TModel>(entity);
        return result;
    }

    public void Update(TModel model)
    {
        var entity = _mapper.Map<TEntity>(model);
        dataContract.Update(entity);
    }
}
