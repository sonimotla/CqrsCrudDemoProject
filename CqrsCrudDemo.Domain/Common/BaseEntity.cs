using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsCrudDemo.Domain.Common
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
