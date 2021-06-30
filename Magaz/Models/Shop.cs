using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Magaz.Models
{
    public class Shop
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Address {get;set;}

        [Required]
        public string City { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Director { get; set; }
    }
}
