using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVCDemo.IDAL
{
    /// <summary>
    /// 接口基类
    /// <remarks>创建：2015.03.30<br/>
    /// 修改：2015.03.30
    /// </remarks>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface InterfaceBaseRepository<T>
    {
        /// <summary>
        /// 数据实体列表
        /// </summary>
        IQueryable<T> Entities { get; }
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns>影响的记录数目</returns>
        int Save();
        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Add(T entity);
        /// <summary>
        /// 查询记录数
        /// </summary>
        /// <param name="entity">条件表达是</param>
        /// <returns>记录数</returns>
        int Count(Expression<Func<T,bool>> predicate);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>记录数</returns>
        bool Update(T entity);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>是否成功</returns>
        bool Delete(T entity);
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="anyLambda">查询表达式</param>
        /// <returns>布尔值</returns>
        bool Exist(Expression<Func<T, bool>> anyLambda);
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="whereLambda">查询表示式</param>
        /// <returns>实体</returns>
        T Find(Expression<Func<T, bool>> whereLambda);
        /// <summary>
        /// 查找数据【优先使用】
        /// </summary>
        /// <param name="ID">主键</param>
        /// <returns>实体</returns>
        T Find(int ID);
        /// <summary>
        /// 查找数据列表
        /// </summary>
        /// <typeparam name="S">排序</typeparam>
        /// <param name="whereLamdba">查询表示式</param>
        /// <param name="orderName">排序名称</param>
        /// <param name="isAsc">是否升序</param>
        /// <returns></returns>
        IQueryable<T> FindList(Expression<Func<T, bool>> whereLamdba,string orderName, bool isAsc);
        /// <summary>
        /// 查询分页数据列表
        /// </summary>
        /// <typeparam name="S">排序</typeparam>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="totalRecoud">总记录数</param>
        /// <param name="whereLamdba">查询表达式</param>
        /// <param name="orderName">排序名称</param>
        /// <param name="isAse">是否升序</param>
        /// <returns></returns>
        IQueryable<T> FindPageList(int pageIndex, int pageSize, out int totalRecoud, Expression<Func<T, bool>> whereLamdba, string orderName,bool isAse);
    }
}
