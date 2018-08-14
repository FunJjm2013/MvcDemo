using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using MVCDemo.DAL;
using MVCDemo.IBLL;
using MVCDemo.Models;

namespace MVCDemo.BLL
{
    /// <summary>
    /// 用户服务类
    /// <remarks>创建：2015.03.30</remarks>
    /// </summary>
    public class UserService : BaseService<User>, InterfaceUserService
    {
        public UserService() :base(RepositoryFactory.UserRepository)
        {

        }

        public ClaimsIdentity CreateIndentity(User user, string authenticationType)
        {
            ClaimsIdentity identity = new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie);
            identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString()));
            identity.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "ASP.NET Identity"));
            identity.AddClaim(new Claim("DisplayName", user.DisplayName));
            return identity;
        }

        public bool Exist(string userName)
        {
            return CurrentRepository.Exist(u => u.UserName == userName);
        }

        public User Find(string userName)
        {
            return CurrentRepository.Find(u => u.UserName == userName);
        }

        //public User Find(int userID)
        //{
        //    return CurrentRepository.Find(u => u.UserID == userID);
        //}

        public IQueryable<User> FindPageList(int pageindex, int pageSize, out int totalRecord, int order)
        {
            bool isAsc = true;
            string orderName = string.Empty;
            switch (order)
            {
                case 0:
                    isAsc = true;
                    orderName = "UserID";
                    break;
                case 1:
                    isAsc = false;
                    orderName = "UserID";
                    break;
                case 2:
                    isAsc = true;
                    orderName = "RegistrationTime";
                    break;
                case 3:
                    isAsc = false;
                    orderName = "RegistrationTime";
                    break;
                case 4:
                    isAsc = true;
                    orderName = "LoginTime";
                    break;
                case 5:
                    isAsc = false;
                    orderName = "LoginTime";
                    break;
                default:
                    isAsc = false;
                    orderName = "UserID";
                    break;
            }
            return CurrentRepository.FindPageList(pageindex, pageSize, out totalRecord, u => true, orderName, isAsc);
        }
    }
}
