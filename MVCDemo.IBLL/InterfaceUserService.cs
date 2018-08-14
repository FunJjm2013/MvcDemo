using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MVCDemo.Models;

namespace MVCDemo.IBLL
{
    /// <summary>
    /// 用户相关接口
    /// <remarks>创建：2015.03.30</remarks>
    /// </summary>
    public interface InterfaceUserService :InterfaceBaseService<User>
    {
        /// <summary>
        /// 用户是否存在
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>布尔值</returns>
        bool Exist(string userName);
        /// <summary>
        /// 查找用户
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        //User Find(int userID);
        /// <summary>
        /// 查找用户
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        User Find(string userName);
        /// <summary>
        /// 用户列表
        /// </summary>
        /// <param name="pageindex">页码数</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="totalRecord">总记录数</param>
        /// <param name="order">排序：0-ID升序（默认），1-ID降序，2注册时间升序，3注册时间降序，4登录时间升序，5登录时间降序</param>
        /// <returns></returns>
        IQueryable<User> FindPageList(int pageindex, int pageSize, out int totalRecord, int order);
        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="authenticationType"></param>
        /// <returns></returns>
        ClaimsIdentity CreateIndentity(User user, string authenticationType);
    }
}
