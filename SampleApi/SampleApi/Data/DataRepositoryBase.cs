using SampleApi.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SampleApi.Data
{
    public abstract class DataRepositoryBase<T> where T : class, new()
    {
      
        protected abstract T AddEntity(Context entityContext, T entity);

        protected abstract T UpdateEntity(Context entityContext, T entity);

        protected abstract IQueryable<T> GetEntities(Context entityContext);
        protected abstract IQueryable<T> GetQueryable();

        protected abstract T GetEntity(Context entityContext, int id);

        public T Add(T entity)
        {
            using(Context entityContext = new Context())
            {
                T addedEntity = AddEntity(entityContext, entity);
                entityContext.SaveChanges();
                return addedEntity;
            }          
        }     

        public void Remove(T entity)
        {
            using(Context entityContext = new Context())
            {
                entityContext.Entry<T>(entity).State = EntityState.Deleted;
                entityContext.SaveChanges();
            }              
        }

        public void Remove(int id)
        {
            using(Context entityContext = new Context())
            {
                T entity = GetEntity(entityContext, id);
                entityContext.Entry<T>(entity).State = EntityState.Deleted;
                entityContext.SaveChanges();
            }
        }

        public T update(T entity)
        {
            using(Context entityContext = new Context())
            {
                T existingEntity = UpdateEntity(entityContext, entity);
                SimpleMapper.PropertyMap(entity, existingEntity);
                entityContext.SaveChanges();
                return existingEntity;
            }
        }

        public IEnumerable<T> Get()
        {
            using (Context entityContext = new Context())
            {
                //return (GetEntities(entityContext).ToArray().AsEnumerable());
                return (GetEntities(entityContext).ToArray().AsEnumerable());
            }          
        }
        public IQueryable<T> Get(Context entityContext)
        {
                //return (GetEntities(entityContext).ToArray().AsEnumerable());
                return (GetEntities(entityContext));
            
        }
        public T Get(int id)
        {   
            using(Context entityContext = new Context())
            {
                return GetEntity(entityContext, id);
            }     
        }

        public IQueryable<T> GetDataSet()
        {
            return (GetQueryable()).AsQueryable();
        }

    }
}