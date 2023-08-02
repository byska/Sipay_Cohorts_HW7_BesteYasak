using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_Cohorts_HW7.Entities.BaseModel
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
