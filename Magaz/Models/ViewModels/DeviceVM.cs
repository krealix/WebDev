using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Magaz.Models.ViewModels
{
    public class DeviceVM
    {
        public Device Device { get; set; }
        public IEnumerable<SelectListItem> DDCountry { get; set; }
        public IEnumerable<SelectListItem> DDBrand { get; set; }
        public IEnumerable<SelectListItem> DDType { get; set; }
    }
}
