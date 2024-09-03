using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Model;
using Project.BLL.Services;
using Project.DAL.Entities;

namespace Project.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepo depart;
        private readonly IMapper mapper;

        public DepartmentController(IDepartmentRepo department, IMapper mapper)
        {
            depart = department;
            this.mapper = mapper;
        }

        public async Task<IActionResult> DepartmentServices()
        {
            var data = await depart.GetAsync();
            var result = mapper.Map<IEnumerable<DepartmentVM>>(data);
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DepartmentVM department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Department>(department);
                    await depart.CreateDepartmentAsync(data);
                    return RedirectToAction("DepartmentServices", "Department");
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            return View(department);
        }

        public async Task<IActionResult> Details(int id)
        {
            var data = await depart.GetByIdAsync(id);
            var result = mapper.Map<DepartmentVM>(data);
            return View(result);
        }

        public async Task<IActionResult> Update(int id)
        {
            var data = await depart.GetByIdAsync(id);
            var result = mapper.Map<DepartmentVM>(data);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Update(DepartmentVM department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Department>(department);
                    await depart.UpdateDepartmentAsync(data);
                    return RedirectToAction("DepartmentServices", "Department");
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            return View(department);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var data = await depart.GetByIdAsync(id);
            var result = mapper.Map<DepartmentVM>(data);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DepartmentVM department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Department>(department);
                    await depart.DeleteDepartmentAsync(data);
                    return RedirectToAction("DepartmentServices", "Department");
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            return View(department);
        }

    }
}
