using AutoMapper;
using Karmchari.Data.Contracts;
using System.Linq.Expressions;

namespace Bridge;

/// <summary>
/// Base class for bridge clients, providing common operations for mapping and interacting with data contracts.
/// </summary>
/// <typeparam name="TEntity">The data entity type.</typeparam>
/// <typeparam name="TModel">The business model type.</typeparam>
public class BaseBridgeClient<TEntity, TModel>
    where TEntity : class
    where TModel : class
{
    private protected readonly IMapper _mapper;
    private protected readonly IDataContractBase<TEntity> dataContract;

    /// <summary>
    /// Initializes a new instance of the BaseBridgeClient class.
    /// </summary>
    /// <param name="mapper">The IMapper instance for mapping entities to models and vice versa.</param>
    /// <param name="dataContract">The IDataContractBase instance for interacting with data.</param>
    public BaseBridgeClient(IMapper mapper, IDataContractBase<TEntity> dataContract)
    {
        _mapper = mapper;
        this.dataContract = dataContract;
    }

    /// <summary>
    /// Adds a new model to the data.
    /// </summary>
    /// <param name="model">The model to add.</param>
    public void Add(TModel model)
    {
        var entity = _mapper.Map<TEntity>(model);
        dataContract.Add(entity);
    }

    /// <summary>
    /// Deletes a model from the data.
    /// </summary>
    /// <param name="model">The model to delete.</param>
    public void Delete(TModel model)
    {
        var entity = _mapper.Map<TEntity>(model);
        dataContract.Delete(entity);
    }

    /// <summary>
    /// Finds models based on the provided predicate.
    /// </summary>
    /// <param name="predicate">The predicate expression for filtering models.</param>
    /// <returns>An IQueryable of models matching the predicate.</returns>
    public IQueryable<TModel> Find(Expression<Func<TModel, bool>> predicate)
    {
        var entityPredicate = _mapper.Map<Expression<Func<TEntity, bool>>>(predicate);
        var entities = dataContract.Find(entityPredicate);
        var results = _mapper.Map<IQueryable<TModel>>(entities);
        return results;
    }

    /// <summary>
    /// Gets all models.
    /// </summary>
    /// <returns>An IEnumerable of all models.</returns>
    public IEnumerable<TModel> GetAll()
    {
        var data = dataContract.GetAll();
        var results = _mapper.Map<IEnumerable<TModel>>(data);
        return results;
    }

    /// <summary>
    /// Gets a model by its ID.
    /// </summary>
    /// <param name="id">The ID of the model.</param>
    /// <returns>The model with the specified ID.</returns>
    public TModel GetById(Guid id)
    {
        var entity = dataContract.GetById(id);
        var result = _mapper.Map<TModel>(entity);
        return result;
    }

    /// <summary>
    /// Updates a model in the data.
    /// </summary>
    /// <param name="model">The model to update.</param>
    public void Update(TModel model)
    {
        var entity = _mapper.Map<TEntity>(model);
        dataContract.Update(entity);
    }
}

