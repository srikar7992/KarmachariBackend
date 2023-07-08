using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessContracts;

public interface IBaseBusinessContract<TModel>
{
    IEnumerable<TModel> GetAll();
    IQueryable<TModel> Find(Expression<Func<TModel, bool>> predicate);
    TModel GetById(Guid id);
    void Add(TModel model);
    void Update(TModel model);
    void Delete(TModel model);
}
