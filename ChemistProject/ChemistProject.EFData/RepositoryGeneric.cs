using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ChemistProject.Core;
using ChemistProject.DALInterfaces;

namespace ChemistProject.EFData
{
    public class RepositoryGeneric<TEnity, TKey> : MainRepository, IRepositoryGeneric<TEnity, TKey> where TEnity : Entity
    {
        private readonly DbSet<TEnity> _set;

        public RepositoryGeneric(ChemistContext context)
            : base(context)
        {
            _set = Context.Set<TEnity>();
        }

        public void Create(TEnity value)
        {
            _set.Add(value);
        }

        public void Update(TEnity value)
        {
            _set.Attach(value);
            Context.Entry(value).State = EntityState.Modified;
        }

        public void Remove(TEnity value)
        {
            _set.Remove(value);
        }

        public TEnity GetEntityById(TKey id)
        {
            var entity = _set.Find(id);
            return entity;
        }

        public TEnity FindEntity(Expression<Func<TEnity, bool>> predicate)
        {
            var entity = _set.SingleOrDefault(predicate);
            return entity;
        }

        public IQueryable<TEnity> All()
        {
            return _set;
        }

        public IQueryable<TEnity> FindEntities(Expression<Func<TEnity, bool>> predicate)
        {
            return _set.Where(predicate);
        }
    }
}
