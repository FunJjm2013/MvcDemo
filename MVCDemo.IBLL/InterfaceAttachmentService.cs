using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCDemo.Models;

namespace MVCDemo.IBLL
{
    /// <summary>
    /// 附件服务接口
    /// <remarks>
    /// 创建：2015.04.07
    /// </remarks>
    /// </summary>
    public interface InterfaceAttachmentService : InterfaceBaseService<Attachment>
    {
        /// <summary>
        /// 查找附件列表
        /// </summary>
        /// <param name="modelID">公共模型ID</param>
        /// <param name="owner">所有者</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        IQueryable<Attachment> FindList(Nullable<int> modelID, string owner, string type);
        /// <summary>
        /// 查找条件列表
        /// </summary>
        /// <param name="modelID">公共模型ID</param>
        /// <param name="owner">所有者</param>
        /// <param name="type">类型</param>
        /// <param name="withModelIDNUll">包含ModelID为Null的</param>
        /// <returns></returns>
        IQueryable<Attachment> FindList(int modelID, string owner, string type, bool withModelIDNUll);
    }
}
