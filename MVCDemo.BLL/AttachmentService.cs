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
    /// 附件服务
    /// <remarks>
    /// 创建：2015.04.08
    /// </remarks>
    /// </summary>
    public class AttachmentService :BaseService<Attachment>,InterfaceAttachmentService
    {
        public AttachmentService() :base(RepositoryFactory.AttachmentRepository)
        {
           
        }
        public  IQueryable<Attachment> FindList(Nullable<int> modelID,string owner,string type)
        {
            var attachments = CurrentRepository.Entities.Where(a => a.ModelID == modelID);
            if (!string.IsNullOrEmpty(owner))
            {
                attachments = attachments.Where(a => a.Owner == owner);
            }
            if (!string.IsNullOrEmpty(owner))
            {
                attachments = attachments.Where(a => a.Type == type);
            }
            return attachments;
        }
        public IQueryable<Attachment> FindList(int modelID, string owner, string type, bool withModelIDNull)
        {
            var attachments = CurrentRepository.Entities;
            if (withModelIDNull)
            {
                attachments = attachments.Where(a => a.ModelID == modelID || a.ModelID == null);
            }
            else
            {
                attachments = attachments.Where(a => a.ModelID == modelID);
            }
            if (!string.IsNullOrEmpty(owner))
            {
                attachments = attachments.Where(a=>a.Owner==owner);
            }
            if (!string.IsNullOrEmpty(type))
            {
                attachments = attachments.Where(a=>a.Type==type);
            }
            return attachments;
        }
    }
}
