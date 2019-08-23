using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.DAL.IRepository;
using DENTALMIS.Model;

namespace DENTALMIS.DAL.Repository
{
   public class Repository<TEntity> :IRepository<TEntity>  where TEntity:class
   {
       protected DENTALERPDbContext Context = null;

       private ObjectContext objectContext = null;

       public Repository(DENTALERPDbContext context)
       {
           Context = context;
           objectContext = ((IObjectContextAdapter)context).ObjectContext;
           Context.Configuration.LazyLoadingEnabled = false;
           Context.Configuration.ProxyCreationEnabled = false;


       }

      
      
       protected DbSet<TEntity> ObjectSet
       {
           get
           {
               return Context.Set<TEntity>();
               
           }
       } 

       public void Dispose()
       {
           if (Context!=null)
           {
               Context.Dispose();
           }
       }

       public virtual TEntity GetById(int? id)
       {
           return ObjectSet.Find(id);
       }

       public virtual IQueryable<TEntity> All()
       {
           return ObjectSet.AsQueryable();
       }

       public virtual IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate)
       {
           return ObjectSet.Where(predicate).AsQueryable<TEntity>();
       }

       public virtual IQueryable<TEntity> Filter<T>(Expression<Func<TEntity, bool>> filter, out int total, int index = 0,int size = 10)
       {
           int skipCount = index*size;

           var _resetSet = filter != null ? ObjectSet.Where(filter).AsQueryable() : ObjectSet.AsQueryable();
           _resetSet = skipCount == 0 ? _resetSet.Take(size) : _resetSet.Skip(skipCount).Take(size);
           total = _resetSet.Count();
           return _resetSet.AsQueryable();
       }
       //public IQueryable<TEntity> Filter<key>(Expression<Func<TEntity, bool>> filetr, out int total, int index = 0, int size = 1000)
       //{
       //    throw new NotImplementedException();
       //}

       public bool Contains(Expression<Func<TEntity, bool>> predicate)
       {
           return ObjectSet.Count(predicate) > 0;
       }

       public virtual TEntity FindOne(Expression<Func<TEntity, bool>> predicate)
       {
           return ObjectSet.FirstOrDefault(predicate);
       }

       public virtual int Delete(TEntity entity)
       {
           ObjectSet.Remove(entity);
           return SaveChanges();
       }

       public virtual int Delete(Expression<Func<TEntity, bool>> predicate)
       {
           var objects = Filter(predicate);
           foreach (var obj in objects)
           {
               ObjectSet.Remove(obj);
           }
           SaveChanges();
           return 0;
       }

       public virtual int Save(TEntity entity)
       {
           var entry = Context.Entry(entity);
           if (entry.State==EntityState.Detached)
           {
               ObjectSet.Add(entity);
               entry.State=EntityState.Added;
           }
           else
           {
               ObjectSet.Attach(entity);
               entry.State=EntityState.Modified;
           }
           return SaveChanges();
       }

       public virtual int Edit(TEntity entity)
       {
           var entry = Context.Entry(entity);
           ObjectSet.Attach(entity);
           entry.State=EntityState.Modified;
           return SaveChanges();
       }

       public virtual int Count()
       {
           return ObjectSet.Count();
       }
       

       public virtual int Count(Expression<Func<TEntity, bool>> predicate)
       {
           return ObjectSet.Count(predicate);
       }

       public bool Exist(Expression<Func<TEntity, bool>> predicate)
       {
           return ObjectSet.Any(predicate);
       }

       public TEntity Add(TEntity entity)
       {
           TEntity addResult = ObjectSet.Add(entity);
           SaveChanges();
           return addResult;
       }

       private int SaveChanges()
       {
           return Context.SaveChanges();
       }

       public virtual TEntity EditEntity(TEntity entity)
       {
           var entry = Context.Entry(entity);
           ObjectSet.Attach(entity);
           entry.State=EntityState.Modified;
           SaveChanges();
           return entity;
       }

       public int SaveList(List<TEntity> entities)
       {
           int save = 0;

           foreach (TEntity entity in entities)
           {
               save += Save(entity);
           }
           return save;
       }

       public List<TEntity> Search(Expression<Func<TEntity,bool>> predicate )
       {
           var query = ObjectSet.Where(predicate);

           var result = query.ToList();
           return result;
       }
       public List<TEntity> Search(Expression<Func<TEntity, bool>> predicate, out int total, int index=0, int size=10)
       {
           var query = ObjectSet.Where(predicate);
           total = query.Count();
           query = query.Skip(index*size).Take(size);
           var result = query.ToList();
           return result;
       } 
   }
}
