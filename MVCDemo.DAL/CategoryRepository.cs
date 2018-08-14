using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCDemo.Models;
using MVCDemo.IDAL;

namespace MVCDemo.DAL
{
    /// <summary>
    /// 栏目类型仓库
    /// <remarks>
    /// 创建：2015.04.07
    /// </remarks>
    /// </summary>
    public class CategoryRepository :BaseRepository<Category>,InterfaceCategoryRepository
    {
    }
}
