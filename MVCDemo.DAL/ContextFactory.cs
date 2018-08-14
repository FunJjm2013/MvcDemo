using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MVCDemo.DAL
{
    /// <summary>
    /// 上下文简单工厂
    /// <remarks>创建：2015.03.30</remarks>
    /// </summary>
    public class ContextFactory
    {
        public static MVCDemoDbContext GetCurrentContext()
        {
            MVCDemoDbContext mvcContext = CallContext.GetData("mvcContext") as MVCDemoDbContext;
            if (mvcContext==null)
            {
                mvcContext = new MVCDemoDbContext();
                CallContext.SetData("mvcContext", mvcContext);
            }
            return mvcContext;
        }
    }
}
