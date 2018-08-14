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
    /// 公共模型仓库
    /// <remarks>
    /// 创建：2015.04.07
    /// 修改：2015.04.29
    /// </remarks>
    /// </summary>
    public class CommonModelRepository :BaseRepository<CommonModel>,InterfaceCommonModelRepository
    {
        public bool Delete(CommonModel commonModel,bool isSave=true) 
        {
            if (commonModel.Attachment!=null)
            {
                mvcContext.Attachments.RemoveRange(commonModel.Attachment);
            }
            if (commonModel.Article!=null)
            {
                mvcContext.Articles.Remove(commonModel.Article);
            }
            if (commonModel.Consultation!=null)
            {
                mvcContext.Consultations.Remove(commonModel.Consultation);
            }
            mvcContext.CommonModels.Remove(commonModel);
            return isSave ? mvcContext.SaveChanges() > 0 : true;
        }
    }
}
