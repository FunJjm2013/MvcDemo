using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCDemo.IBLL;
using MVCDemo.IDAL;

namespace MVCDemo.BLL
{
    /// <summary>
    /// 服务基类
    /// <remraks>创建：2015.03.30</remraks>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseService<T> :InterfaceBaseService<T> where T :class,new()
    {
        protected InterfaceBaseRepository<T> CurrentRepository { get; set; }
        public BaseService(InterfaceBaseRepository<T> currentRepository)
        {
            CurrentRepository = currentRepository;
        }
        public T Add(T entity)
        {
            return CurrentRepository.Add(entity);
        }

        public bool Delete(T entity)
        {
            return CurrentRepository.Delete(entity);
        }

        public bool Update(T entity)
        {
            return CurrentRepository.Update(entity);
        }
        public IQueryable<T> PageList(IQueryable<T> entitys, int pageIndex, int pageSize)
        {
            return entitys.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }


        public T Find(int ID)
        {
            return CurrentRepository.Find(ID);
        }
    }
}
