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
    /// 栏目服务
    /// <remarks>
    /// 创建：2015.04.07
    /// </remarks>
    /// </summary>
    public class CategoryService :BaseService<Category>,InterfaceCategoryService
    {
        public CategoryService() :base(RepositoryFactory.CategoryRepository)
        {

        }
        public List<EasyuiTreeNodeViewModel> EasyuiTreeData(string model)
        {
            //栏目ID列表
            Dictionary<string, int> categoryIDList = new Dictionary<string, int>();
            //查询栏目列表
            IQueryable<Category> categoryList = CurrentRepository.Entities.OrderBy(c => c.Order);
            if (!string.IsNullOrEmpty(model))
            {
                categoryList = categoryList.Where(c => c.Model == model);
            }
            //栏目partentParth
            var partentParthList = categoryList.Select(c => c.ParentPath).ToList();
            //遍历partentParth
            foreach (var partentParth in partentParthList)
            {
                //将partentParth分割为ID字符串列表
                var strCategoryIDList = partentParth.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                //将CategoryID循环添加到栏目ID列表
                foreach (var strCategoryID in strCategoryIDList)
                {
                    if (!categoryIDList.ContainsKey(strCategoryID))
                    {
                        categoryIDList.Add(strCategoryID,int.Parse(strCategoryID));
                    }
                }
            }
            //栏目树
            List<EasyuiTreeNodeViewModel> tree = new List<EasyuiTreeNodeViewModel>();
            //树栏目列表
            IQueryable<Category> categoryTreeList = CurrentRepository.Entities.Where(c => categoryIDList.Values.Contains(c.ParentId)).OrderByDescending(c => c.ParentPath).ThenBy(c => c.Order);
            foreach (var categoryTree in categoryTreeList)
            {
                if (tree.Exists(n=>n.parentid==categoryTree.CategoryID))
                {
                    var children = tree.Where(n => n.parentid == categoryTree.CategoryID).ToList();
                    tree.RemoveAll(n => n.parentid == categoryTree.CategoryID);
                    tree.Add(new EasyuiTreeNodeViewModel() { id = categoryTree.CategoryID, parentid = categoryTree.ParentId, text = categoryTree.Name, children = children });
                }
                else
                {
                    tree.Add(new EasyuiTreeNodeViewModel() { id = categoryTree.CategoryID, parentid = categoryTree.ParentId, text = categoryTree.Name });
                }
            }
            return tree;
        }
        public List<Category> FindList(string model)
        {
            return CurrentRepository.Entities.Where(c => c.Model == model).ToList();
        }
    }
}
