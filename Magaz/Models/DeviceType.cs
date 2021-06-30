using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Magaz.Models
{
    public class DeviceType
    {   
        [Key]
        public int Id { get; set; }
        [Required]
        public string TypeName { get; set; }
    }
}
