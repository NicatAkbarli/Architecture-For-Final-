using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Architecture.Core.DataAccess.EntityFramework.Abstract.Abstract
{
    public interface IRepositoryBase<TEntity>
    {
        
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    List<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter=null);
    TEntity Get(Expression<Func<TEntity, bool>> filter);
 
    }
}