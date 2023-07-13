using EntityDbContext;
using Karmchari.Data.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Karmchari.Data.Repositories;

/// <summary>
/// Base class for a data repository providing common CRUD operations for entities.
/// </summary>
/// <typeparam name="TEntity">The entity type.</typeparam>
public class DataRepositoryBase<TEntity> : IDataContractBase<TEntity> where TEntity : class
{
    private protected readonly KarmachariDbContext _context;
    private protected readonly DbSet<TEntity> _dbSet;

    /// <summary>
    /// Initializes a new instance of the DataRepositoryBase class.
    /// </summary>
    /// <param name="context">The DbContext instance used for database access.</param>
    /// <exception cref="ArgumentNullException">Thrown when the context parameter is null.</exception>
    public DataRepositoryBase(KarmachariDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _dbSet = _context.Set<TEntity>();
    }

    /// <summary>
    /// Retrieves all entities from the repository.
    /// </summary>
    /// <returns>An IQueryable of all entities.</returns>
    public IEnumerable<TEntity> GetAll()
    {
        return _dbSet.AsNoTracking();
    }

    /// <summary>
    /// Finds entities in the repository based on the specified predicate.
    /// </summary>
    /// <param name="predicate">The predicate expression used to filter entities.</param>
    /// <returns>An IQueryable of entities matching the predicate.</returns>
    public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
    {
        return _dbSet.AsNoTracking().Where(predicate);
    }

    /// <summary>
    /// Retrieves an entity from the repository by its ID.
    /// </summary>
    /// <param name="id">The ID of the entity to retrieve.</param>
    /// <returns>The entity with the specified ID, or null if not found.</returns>
    public TEntity? GetById(Guid id)
    {
        return _dbSet.Find(id);
    }

    /// <summary>
    /// Adds a new entity to the repository.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    public void Add(TEntity entity)
    {
        _dbSet.Add(entity);
    }

    /// <summary>
    /// Updates an existing entity in the repository.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    public void Update(TEntity entity)
    {
        _dbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }

    /// <summary>
    /// Deletes an entity from the repository.
    /// </summary>
    /// <param name="entity">The entity to delete.</param>
    public void Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
    }
}

