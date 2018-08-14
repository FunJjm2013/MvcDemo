using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDemo.Models
{
    /// <summary>
    /// 附件
    /// <remarks>
    /// 创建：2015.04.07
    /// </remarks>
    /// </summary>
    public class Attachment
    {
        public int AttachmentID { get; set; }
        /// <summary>
        /// 模型ID
        /// </summary>
        public Nullable<int> ModelID { get; set; }
        /// <summary>
        /// 拥有者
        /// </summary>
        public string Owner { get; set; }
        /// <summary>
        /// 附件类型 image,flash,media,file四种类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 扩展名
        /// </summary>
        public string Extension { get; set; }
        /// <summary>
        /// 文件路径
        /// </summary>
        public string FileParth { get; set; }
        /// <summary>
        /// 上传日期
        /// </summary>
        public DateTime UploadDate { get; set; }
    }
}
