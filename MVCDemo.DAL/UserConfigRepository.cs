using System;
using System.Linq;
using System.Linq.Expressions;
using MVCDemo.IDAL;
using MVCDemo.Models;

namespace MVCDemo.DAL
{
    public class UserConfigRepository :BaseRepository<UserConfig>, InterfaceUserConfigRepository
    {
        
    }
}