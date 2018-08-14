using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCDemo.IDAL;
using MVCDemo.Models;

namespace MVCDemo.DAL
{
    /// <summary>
    /// 用户仓库
    /// <remarks>创建：2015.03.30</remarks>
    /// </summary>
    public class UserRepository :BaseRepository<User>,InterfaceUserRepository
    {

    }
}
