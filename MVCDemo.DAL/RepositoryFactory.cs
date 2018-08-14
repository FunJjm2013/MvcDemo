using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCDemo.IDAL;

namespace MVCDemo.DAL
{
    /// <summary>
    /// 简单工厂？
    /// <remarks>创建：2015.03.30</remarks>
    /// </summary>
    public class RepositoryFactory
    {
        /// <summary>
        /// 用户仓储
        /// </summary>
        public static InterfaceUserRepository UserRepository { get { return new UserRepository(); } }
        /// <summary>
        /// 角色仓储
        /// </summary>
        public static InterfaceRoleRepository RoleRepository { get { return new RoleRepository(); } }
        /// <summary>
        /// 用户配置仓储
        /// </summary>
        public static InterfaceUserConfigRepository UserConfigRepository { get { return new UserConfigRepository(); } }
        /// <summary>
        /// 栏目仓储
        /// </summary>
        public static InterfaceCategoryRepository CategoryRepository { get { return new CategoryRepository(); } }
        /// <summary>
        /// 文章仓储
        /// </summary>
        public static InterfaceArticleRepository ArticleRepository { get { return new ArticleRepository(); } }
        /// <summary>
        /// 附件仓储
        /// </summary>
        public static InterfaceAttachmentRepository AttachmentRepository { get{ return new AttachmentRepository(); } }
        /// <summary>
        /// 评论仓储
        /// </summary>
        public static InterfaceCommentRepository CommentRepository { get {return new CommentRepository(); } }
        /// <summary>
        /// 公共模型仓储
        /// </summary>
        public static InterfaceCommonModelRepository CommonModelRepository { get { return new CommonModelRepository(); } }
        /// <summary>
        /// 咨询仓储
        /// </summary>
        public static InterfaceConsultationRepository ConsultationRepository { get { return new ConsultationRepository(); } }
    }
}
