using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDemo.Models
{
    /// <summary>
    /// Easyui Tree数据
    /// <remarks>
    /// 创建：2015.04.08
    /// </remarks>
    /// </summary>
    public class EasyuiTreeNodeViewModel
    {
        /// <summary>
        /// 节点ID
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 父节点ID
        /// </summary>
        public int parentid { get; set; }
        /// <summary>
        /// 节点文字
        /// </summary>
        public string text { get; set; }
        /// <summary>
        /// 节点状态：'open'或者'closed'
        /// </summary>
        public string state { get; set; }
        /// <summary>
        /// 节点属性
        /// </summary>
        public object attributes { get; set; }
        /// <summary>
        /// 子节点
        /// </summary>
        public List<EasyuiTreeNodeViewModel> children { get; set; }
    }
}
