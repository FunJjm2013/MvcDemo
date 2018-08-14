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
    /// 评论仓储
    /// <remarks>
    /// 创建：2015.04.07
    /// </remarks>
    /// </summary>
    public class CommentRepository :BaseRepository<Comment>,InterfaceCommentRepository
    {

    }
}
