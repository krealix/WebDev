using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Magaz.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Amount { get; set; }

        [DisplayName("Device")]
        public int DeviceId { get; set; }
        [DisplayName("User")]
        public string UserId { get; set; }


        [ForeignKey("DeviceId")]
        public virtual Device Device { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public bool IsCart { get; set; }

        public bool IsPack { get; set; }

        public string Status { get; set; }
    }
}
