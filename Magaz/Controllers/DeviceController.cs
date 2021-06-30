using Magaz.Data;
using Magaz.Models;
using Magaz.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Magaz.Controllers
{
    public class DeviceController : Controller
    {
        public readonly DataDbContext _db;

        public DeviceController(DataDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            IEnumerable<Device> objList = _db.Devices;

            foreach(var obj in objList)
            {
                obj.DeviceTypes = _db.DeviceTypes.FirstOrDefault(u => u.Id == obj.TypeId);
                obj.Brand = _db.Brands.FirstOrDefault(u => u.Id == obj.TypeId);
                obj.Country = _db.Countries.FirstOrDefault(u => u.Id == obj.TypeId);

            }

            return View(objList);
        }

        // GET-Create
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {

            DeviceVM DeviceVM = new DeviceVM()
            {
                Device = new Device(),
                DDBrand = _db.Brands.Select(i => new SelectListItem
                {
                    Text = i.BrandName,
                    Value = i.Id.ToString()
                }),
                DDCountry = _db.Countries.Select(i => new SelectListItem
                {
                    Text = i.CountryName,
                    Value = i.Id.ToString()
                }),
                DDType = _db.DeviceTypes.Select(i => new SelectListItem
                {
                    Text = i.TypeName,
                    Value = i.Id.ToString()
                })
            };

            return View(DeviceVM);
        }

        // POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public IActionResult Create(DeviceVM obj)
        {
            if (ModelState.IsValid)
            {
                //obj.ExpenseTypeId = 1;
                _db.Devices.Add(obj.Device);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        // GET Delete
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Devices.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }

        // POST Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Devices.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Devices.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        // GET Update
        [Authorize(Roles = "admin, moderator")]
        public IActionResult Update(int? id)
        {
            DeviceVM DeviceVM = new DeviceVM()
            {
                Device = new Device(),
                DDBrand = _db.Brands.Select(i => new SelectListItem
                {
                    Text = i.BrandName,
                    Value = i.Id.ToString()
                }),
                DDCountry = _db.Countries.Select(i => new SelectListItem
                {
                    Text = i.CountryName,
                    Value = i.Id.ToString()
                }),
                DDType = _db.DeviceTypes.Select(i => new SelectListItem
                {
                    Text = i.TypeName,
                    Value = i.Id.ToString()
                })
            };

            if (id == null || id == 0)
            {
                return NotFound();
            }
            DeviceVM.Device = _db.Devices.Find(id);
            if (DeviceVM.Device == null)
            {
                return NotFound();
            }
            return View(DeviceVM);

        }

        // POST UPDATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin, moderator")]
        public IActionResult Update(DeviceVM obj)
        {
            if (ModelState.IsValid)
            {
                _db.Devices.Update(obj.Device);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Device = await _db.Devices.Include(b=>b.Brand).Include(c=>c.Country).Include(t=>t.DeviceTypes)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Device == null)
            {
                return NotFound();
            }

            return View(Device);

        }



    }
}
