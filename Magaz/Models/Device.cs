using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Magaz.Models
{
    public class Device
    {   
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Cost { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Brand")]
        public int BrandId { get; set; }
        [DisplayName("Country")]
        public int CountryId { get; set; }
        [DisplayName("Type")]
        public int TypeId { get; set; }

        [ForeignKey("BrandId")]
        public Brand Brand { get; set; }
        [ForeignKey("CountryId")]
        public Country Country { get; set; }
        [ForeignKey("TypeId")]
        public  DeviceType DeviceTypes { get; set; }

        [DisplayName("Color")]
        public string Color { get; set; }
        [DisplayName("Buttons Amounts Mouse")]
        public int Buttons_Amounts { get; set; }
        [DisplayName("Type Sensor")]
        public string Type_Sensor { get; set; }
        [DisplayName("Sensor")]
        public string Sensor { get; set; }
        [DisplayName("DPI")]
        public int DPI { get; set; }
        [DisplayName("Material Mouse")]
        public string Material_M {get; set; }
        [DisplayName("Type Connect")]
        public string Type_Connect { get; set; }
        [DisplayName("Weight Mouse")]
        public string Weight_M { get; set; }
        [DisplayName("Type Keyboard")]
        public string Type_Keyboard { get; set; }
        [DisplayName("Color Keyboard")]
        public string Color_K { get; set; }
        [DisplayName("Buttons Amount Keyboard")]
        public int Buttons_Amount_K { get; set; }
        [DisplayName("Type Connect")]
        public string Type_Connect_K { get; set; }
        [DisplayName("Material Keyboard")]
        public string Material_K { get; set; }
        [DisplayName("Weight Keyboard")]
        public string Weight_K { get; set; }
        [DisplayName("Type Connect Headphones")]
        public string Type_Connect_H { get; set; }
        [DisplayName("Sound")]
        public string Sound { get; set; }
        [DisplayName("Color Headphones")]
        public string Color_H { get; set; }
        [DisplayName("Min Frequency")]
        public int Min_Frequency { get; set; }
        [DisplayName("Max Frequency")]
        public int Max_Frequency { get; set; }
        [DisplayName("Microfon")]
        public bool Micro { get; set; }
        [DisplayName("Material Headphones")]
        public string Material_H { get; set; }
        [DisplayName("Weight Headphones")]
        public string Weight_H { get; set; }
    }
}
