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
    /// 咨询服务
    /// </summary>
    public class ConsultationService :BaseService<Consultation>,InterfaceConsultationService
    {
        public ConsultationService() :base(RepositoryFactory.ConsultationRepository)
        {

        }
    }
}
