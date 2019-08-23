using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.Model;

namespace DENTALMIS.DAL.IRepository
{
  public  interface IRepository<T> :IDisposable where T:class
  {
      /// <summary>
      /// 
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      T GetById(int? id);
      /// <summary>
      /// 
      /// </summary>
      /// <returns></returns>
      IQueryable<T> All();
      /// <summary>
      /// 
      /// </summary>
      /// <param name="predicate"></param>
      /// <returns></returns>
      IQueryable<T> Filter(Expression<Func<T, bool>> predicate);
      /// <summary>
      /// 
      /// </summary>
      /// <typeparam name="key"></typeparam>
      /// <param name="filetr"></param>
      /// <param name="total"></param>
      /// <param name="index"></param>
      /// <param name="size"></param>
      /// <returns></returns>
      IQueryable<T> Filter<key>(Expression<Func<T, bool>> filetr,
          out int total, int index = 0, int size = 10);
      /// <summary>
      /// 
      /// </summary>
      /// <param name="predicate"></param>
      /// <returns></returns>
      bool Contains(Expression<Func<T, bool>> predicate);
      /// <summary>
      /// 
      /// </summary>
      /// <param name="predicate"></param>
      /// <returns></returns>
      T FindOne(Expression<Func<T, bool>> predicate);
      /// <summary>
      /// 
      /// </summary>
      /// <param name="t"></param>
      /// <returns></returns>
      int Delete(T  t );
      /// <summary>
      /// 
      /// </summary>
      /// <param name="predicate"></param>
      /// <returns></returns>
      int Delete(Expression<Func<T, bool>> predicate);
      
      //void Delete(T t);

      int Save(T t);

      int Edit(T t);

      int Count();

      /// <summary>
      /// 
      /// </summary>
      /// <param name="predicate"></param>
      /// <returns></returns>
      /// 
      /// 
      /// 
      //List<int> CountList(); 
      int Count(Expression<Func<T, bool>> predicate);
      /// <summary>
      /// 
      /// </summary>
      /// <param name="predicate"></param>
      /// <returns></returns>
      bool Exist(Expression<Func<T, bool>> predicate);
      /// <summary>
      /// 
      /// </summary>
      /// <param name="t"></param>
      /// <returns></returns>
      T Add(T t);
      /// <summary>
      /// 
      /// </summary>
      /// <param name="entity"></param>
      /// <returns></returns>
      T EditEntity(T entity);
      /// <summary>
      /// 
      /// </summary>
      /// <param name="enList"></param>
      /// <returns></returns>
      int SaveList(List<T> enList);





  }
}
