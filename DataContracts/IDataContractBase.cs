using System.Linq.Expressions;

namespace Karmchari.Data.Contracts;

public interface IDataContractBase<TEntity> where TEntity : class
{
    IEnumerable<TEntity> GetAll();
    IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    TEntity? GetById(Guid id);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}
