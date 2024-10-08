using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.BLL.Helper;
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
        private readonly ICityRepo city;
        private readonly IDistrictRepo district;

        public EmployeeController(IEmployeeRepo emp, IMapper mapper, IDepartmentRepo department, ICityRepo city, IDistrictRepo district)
        {
            this.emp = emp;
            this.mapper = mapper;
            this.department = department;
            this.city = city;
            this.district = district;
        }

        public async Task<IActionResult> EmployeeServices(string searchvalue)
        {
            if (searchvalue is null)
            {
                var data = await emp.GetAsync(emp => emp.IsActive == true && emp.IsDeleted == false);
                var result = mapper.Map<IEnumerable<EmployeeVM>>(data);
                return View(result);
            }
            else
            {
                var data = await emp.GetAsync(emp => (emp.Employee_Fname + emp.Employee_Lname).Contains(searchvalue) && emp.IsActive == true && emp.IsDeleted == false);
                var result = mapper.Map<IEnumerable<EmployeeVM>>(data);
                return View(result);
            }

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
                    employee.CVName = employee.CV.UploadFile("Docs");
                    employee.ImageName = employee.Image.UploadFile("Imgs");
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

        public async Task<IActionResult> Details(int id)
        {
            var data = await emp.GetByAsync(emp => emp.Employee_Id == id && emp.IsActive == true);
            var result = mapper.Map<EmployeeVM>(data);
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await emp.GetByAsync(emp => emp.Employee_Id == id && emp.IsActive == true && emp.IsDeleted == false);
            var result = mapper.Map<EmployeeVM>(data);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(EmployeeVM employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Employee>(employee);
                    await emp.DeleteEmployeeAsync(data);
                    return RedirectToAction("EmployeeServices", "Employee");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
            return View(employee);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var departments = await department.GetAsync();
            ViewBag.departmentlist = new SelectList(departments, "Department_Id", "Department_Name");
            var data = await emp.GetByAsync(emp => emp.Employee_Id == id && emp.IsActive == true && emp.IsDeleted == false);
            var result = mapper.Map<EmployeeVM>(data);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Update(EmployeeVM employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Employee>(employee);
                    await emp.UpdateEmployeeAsync(data);
                    return RedirectToAction("EmployeeServices", "Employee");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
            return View(employee);
        }

        [HttpGet]
        public async Task<IActionResult> FinalDelete(int id)
        {
            var data = await emp.GetByAsync(emp => emp.Employee_Id == id && emp.IsActive == true && emp.IsDeleted == true);
            var result = mapper.Map<EmployeeVM>(data);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> FinalDelete(EmployeeVM employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    employee.CV.RemoveFile("Docs");
                    employee.Image.RemoveFile("Imgs");
                    var data = mapper.Map<Employee>(employee);
                    await emp.FinalDeleteAsync(data);
                    return RedirectToAction("DeletedEmployee", "Employee");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
            return View(employee);
        }

        public async Task<IActionResult> DeletedEmployee()
        {
            var data = await emp.GetAsync(emp => emp.IsActive == true && emp.IsDeleted == true);
            var result = mapper.Map<IEnumerable<EmployeeVM>>(data);
            return View(result);
        }

        public async Task<IActionResult> ReturnEmployee(int id)
        {
            var result = await emp.GetByAsync(emp => emp.Employee_Id == id);
            await emp.ReturnEmployeeAsync(result);
            return RedirectToAction("EmployeeServices");
        }

        [HttpPost]
        public async Task<JsonResult> GetCitiesByCountryId(int countryid)
        {
            var data = await city.GetAsync(cit => cit.Country_Id == countryid);
            var result = mapper.Map<IEnumerable<CityVM>>(data);
            return Json(result);
        }

        [HttpPost]
        public async Task<JsonResult> GetDistrictsByCityId(int cityid)
        {
            var data = await district.GetAsync(dis => dis.City_Id == cityid);
            var result = mapper.Map<IEnumerable<DistrictVM>>(data);
            return Json(result);
        }

    }
}
