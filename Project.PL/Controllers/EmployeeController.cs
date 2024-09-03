using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.BLL.Model;
using Project.BLL.Services;
using Project.DAL.Entities;

namespace Project.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepo emp;
        private readonly IMapper mapper;
        private readonly IDepartmentRepo department;

        public EmployeeController(IEmployeeRepo emp, IMapper mapper, IDepartmentRepo department)
        {
            this.emp = emp;
            this.mapper = mapper;
            this.department = department;
        }

        public async Task<IActionResult> EmployeeServices()
        {
            var data = await emp.GetAsync();
            var result = mapper.Map<IEnumerable<EmployeeVM>>(data);
            return View(result);
        }

        public async Task<IActionResult> Create()
        {
            var data = await department.GetAsync();
            ViewBag.departmentlist = new SelectList(data, "Department_Id", "Department_Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeVM employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Employee>(employee);
                    await emp.CreateEmployeeAsync(data);
                    return RedirectToAction("EmployeeServices", "Employee");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
            var departments = await department.GetAsync();
            ViewBag.departmentlist = new SelectList(departments, "Department_Id", "Department_Name");
            return View(employee);
        }

    }
}
