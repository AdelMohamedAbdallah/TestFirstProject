using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Helper;
using Project.BLL.Model;
using Project.BLL.Services;
using Project.DAL.Entities;


namespace Project.Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepo emp;
        private readonly IMapper mapper;

        public EmployeeController(IEmployeeRepo emp, IMapper mapper)
        {
            this.emp = emp;
            this.mapper = mapper;
        }


        [HttpGet]
        [Route("~/api/Employee/GetEmployees")]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var data = await emp.GetAsync();
                var result = mapper.Map<IEnumerable<EmployeeVM>>(data);
                return Ok(new ApiResponse<IEnumerable<EmployeeVM>>()
                {
                    Code = 200,
                    Status = "Ok",
                    Message = "Succed",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return NotFound(new ApiResponse<string>()
                {
                    Code = 404,
                    Status = "Not Found",
                    Message = "Not Found",
                    Data = ex.Message
                });
            }
        }

        [HttpGet]
        [Route("~/api/Employee/GetEmployeeById/{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            try
            {
                var data = await emp.GetByAsync(emp => emp.Employee_Id == id);
                var result = mapper.Map<EmployeeVM>(data);
                return Ok(new ApiResponse<EmployeeVM>()
                {
                    Code = 200,
                    Status = "Ok",
                    Message = "Succed",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return NotFound(new ApiResponse<string>()
                {
                    Code = 404,
                    Status = "Not Found",
                    Message = "Not Found",
                    Data = ex.Message
                });
            }
        }

        [HttpPost]
        [Route("~/api/Employee/PostEmployee")]
        public async Task<IActionResult> PostEmployee(EmployeeVM employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //employee.CVName = employee.CV?.UploadFile("Docs");
                    //employee.ImageName = employee.Image?.UploadFile("Imgs");
                    var data = mapper.Map<Employee>(employee);
                    await emp.CreateEmployeeAsync(data);
                    return Ok(new ApiResponse<Employee>()
                    {
                        Code = 201,
                        Status = "Create",
                        Message = "Data Saved",
                        Data = data
                    });
                }
                return BadRequest(new ApiResponse<string>()
                {
                    Code = 400,
                    Status = "Not Created",
                    Message = "Validation Erorr",
                });

            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<string>()
                {
                    Code = 400,
                    Status = "Not Created",
                    Message = "Not Created",
                    Data = ex.Message
                });
            }
        }

        [HttpPut]
        [Route("~/api/Employee/PutEmployee")]
        public async Task<IActionResult> PutEmployee(EmployeeVM employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Employee>(employee);
                    await emp.UpdateEmployeeAsync(data);
                    return Ok(new ApiResponse<Employee>
                    {
                        Code = 202,
                        Message = "Updated",
                        Status = "Accepted",
                        Data = data
                    });
                }
                return BadRequest(new ApiResponse<string>
                {
                    Code = 400,
                    Status = "Not Updated",
                    Message = "Validation Error",
                });
            }
            catch (Exception ex)
            {
                return NotFound(new ApiResponse<string>
                {
                    Code = 304,
                    Status = "Not Modified",
                    Message = "Not Modified",
                    Data = ex.Message
                });
            }

        }

        [HttpDelete]
        [Route("~/api/Employee/SoftDeleteEmployee")]
        public async Task<IActionResult> SoftDeleteEmployee(EmployeeVM employee)
        {
            try
            {
                var data = mapper.Map<Employee>(employee);
                await emp.DeleteEmployeeAsync(data);
                return Ok(new ApiResponse<Employee>
                {
                    Code = 200,
                    Status = "Deleted",
                    Message = "Data Is Deleted",
                    Data = data
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<string>
                {
                    Code = 400,
                    Status = "Not Deleted",
                    Message = "Data Not Deleted",
                    Data = ex.Message
                });
            }
        }

        [HttpDelete]
        [Route("~/api/Employee/DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(EmployeeVM employee)
        {
            try
            {
                //employee.CV?.RemoveFile("Docs");
                //employee.Image?.RemoveFile("Imgs");
                var data = mapper.Map<Employee>(employee);
                await emp.FinalDeleteAsync(data);
                return Ok(new ApiResponse<Employee>
                {
                    Code = 200,
                    Status = "Deleted",
                    Message = "Data Is Deleted",
                    Data = data
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<string>
                {
                    Code = 400,
                    Status = "Not Deleted",
                    Message = "Data Not Deleted",
                    Data = ex.Message
                });
            }
        }

    }
}
