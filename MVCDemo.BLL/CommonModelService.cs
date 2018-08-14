using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCDemo.IBLL;
using MVCDemo.Models;
using MVCDemo.DAL;

namespace MVCDemo.BLL
{
    /// <summary>
    /// 公共服务
    /// <remarks>
    /// 创建：2015.04.08
    /// </remarks>
    /// </summary>
    public class CommonModelService :BaseService<CommonModel>,InterfaceCommonModelService
    {
        public CommonModelService() :base(RepositoryFactory.CommonModelRepository)
        {

        }
        public IQueryable<CommonModel> FindList(int number, string model, string title, int categoryID, string inputer, Nullable<DateTime> fromDate, Nullable<DateTime> toDate, int orderCode)
        {
            return FindPageList(out number, 1, number, model, title, categoryID, inputer, fromDate, toDate,orderCode);
        }
        public IQueryable<CommonModel> FindPageList(out int totalRecord, int pageIndex, int pageSize, string model, string title, int categoryID, string inputer, Nullable<DateTime> fromDate, Nullable<DateTime> toDate, int orderCode)
        {
            IQueryable<CommonModel> commomModels = CurrentRepository.Entities;
            if (model==null||model!="All")
            {
                commomModels = commomModels.Where(cm => cm.Model == model);
            }
            if (!string.IsNullOrEmpty(title))
            {
                commomModels = commomModels.Where(cm => cm.Title.Contains(title));
            }
            if (categoryID>0)
            {
                commomModels = commomModels.Where(cm => cm.CategoryID == categoryID);
            }
            if (!string.IsNullOrEmpty(inputer))
            {
                commomModels = commomModels.Where(cm => cm.Inputer == inputer);
            }
            if (fromDate!=null)
            {
                commomModels = commomModels.Where(cm => cm.ReleaseDate >= fromDate);
            }
            if (toDate!=null)
            {
                commomModels = commomModels.Where(cm => cm.ReleaseDate <= toDate);
            }
            commomModels = Order(commomModels, orderCode);
            totalRecord = commomModels.Count();
            return PageList(commomModels, pageIndex, pageSize).AsQueryable();
        }
        public IQueryable<CommonModel> Order(IQueryable<CommonModel> entitys, int orderCode)
        {
            switch (orderCode)
            {
                //默认排序
                default:
                    entitys = entitys.OrderByDescending(cm => cm.ReleaseDate);
                    break;
            }
            return entitys;
        }
    }
}
