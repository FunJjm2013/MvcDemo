﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCDemo.IDAL;
using MVCDemo.Models;

namespace MVCDemo.DAL
{
    /// <summary>
    /// 附件仓库
    /// <remarks>
    /// 创建：2015.04.07
    /// </remarks>
    /// </summary>
    public class AttachmentRepository :BaseRepository<Attachment>,InterfaceAttachmentRepository
    {
    }
}
