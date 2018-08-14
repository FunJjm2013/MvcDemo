using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCDemo.DAL;
using MVCDemo.IBLL;
using MVCDemo.Models;

namespace MVCDemo.BLL
{
    /// <summary>
    /// 文章服务
    /// </summary>
    public class ArticleService :BaseService<Article>,InterfaceArticleService
    {
        public ArticleService() :base(RepositoryFactory.ArticleRepository)
        {

        }
    }
}
