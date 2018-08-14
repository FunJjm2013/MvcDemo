using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDemo.Models
{
    public abstract class BaseEntity<T>
    {
        public virtual T Id { get; set; }
    }

    public abstract class BaseEntity: BaseEntity<int>
    {
        public override int Id { get; set; }
    }
}
