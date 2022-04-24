using System.Collections.Generic;
using CircusDataAccessLibrary.Data;

namespace CircusDataAccessLibrary.Repositories.Interfaces
{
    public interface IRepository<TEntity, in TId>
        where TId : struct
        where TEntity : BaseEntity<TId>
    {
        public void Create(TEntity entity);
        public List<TEntity> Read();
        public void Update(TEntity entity);
        public void Delete(TId entityId);
    }
}