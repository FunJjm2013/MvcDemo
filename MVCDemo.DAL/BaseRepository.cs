using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCDemo.Models;
using MVCDemo.IDAL;
using System.Linq.Expressions;

namespace MVCDemo.DAL
{
    /// <summary>
    /// 仓储基类
    /// <remarks>
    /// 创建：2015.03.30 <br/>
    /// 修改：2015.04.08
    /// </remarks>
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public class BaseRepository<T> : InterfaceBaseRepository<T> where T : class,new()
    {
        protected MVCDemoDbContext mvcContext = ContextFactory.GetCurrentContext();

        public IQueryable<T> Entities
        {
            get
            {
                return mvcContext.Set<T>();
            }
        }

        public int Save()
        {
            return mvcContext.SaveChanges();
        }
        public T Add(T entity)
        {
            mvcContext.Entry<T>(entity).State = System.Data.Entity.EntityState.Added;
            mvcContext.SaveChanges();
            return entity;
        }

        public int Count(Expression<Func<T,bool>> predicate)
        {
            return mvcContext.Set<T>().Count(predicate);
        }

        public bool Update(T entity)
        {
            mvcContext.Set<T>().Attach(entity);
            mvcContext.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;
            return mvcContext.SaveChanges()>0;
        }

        public bool Delete(T entity)
        {
            mvcContext.Set<T>().Attach(entity);
            mvcContext.Entry<T>(entity).State = System.Data.Entity.EntityState.Deleted;
            return mvcContext.SaveChanges() > 0;
        }

        public bool Exist(Expression<Func<T, bool>> anyLambda)
        {
            return mvcContext.Set<T>().Any(anyLambda);
        }

        public T Find(Expression<Func<T, bool>> whereLambda)
        {
            T entity = mvcContext.Set<T>().FirstOrDefault<T>(whereLambda);
            return entity;
        }
        public T Find(int ID)
        {
            return mvcContext.Set<T>().Find(ID);
        }

        public IQueryable<T> FindList(Expression<Func<T, bool>> whereLamdba, string orderName, bool isAsc)
        {
            var list=mvcContext.Set<T>().Where(whereLamdba);
            list = OrderBy(list, orderName, isAsc);
            return list;
        }

        public IQueryable<T> FindPageList(int pageIndex, int pageSize, out int totalRecoud, Expression<Func<T, bool>> whereLamdba, string orderName, bool isAsc)
        {
            var list = mvcContext.Set<T>().Where<T>(whereLamdba);
            totalRecoud = list.Count();
            list = OrderBy(list, orderName, isAsc).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            return list;
        }
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="source">原IQueryable</param>
        /// <param name="propertyName">排序属性名</param>
        /// <param name="isAsc">是否正序</param>
        /// <returns>排序后的IQueryable</returns>
        private IQueryable<T> OrderBy(IQueryable<T> source, string propertyName, bool isAsc)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source", "不能为空");
            }
            if (string.IsNullOrEmpty(propertyName))
            {
                return source;
            }
            var parameter = Expression.Parameter(source.ElementType);
            var property = Expression.Property(parameter, propertyName);
            if (property == null)
            {
                throw new ArgumentNullException("propertyName", "属性不存在");
            }
            var lambda = Expression.Lambda(property, parameter);
            var methodName = isAsc ? "OrderBy" : "OrderByDescengding";
            var resultExpression = Expression.Call(typeof(Queryable), methodName, new Type[] { source.ElementType, property.Type }, source.Expression, Expression.Quote(lambda));
            return source.Provider.CreateQuery<T>(resultExpression);
        }

    }
}
