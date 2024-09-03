using System.ComponentModel.DataAnnotations;

namespace Project.BLL.Model
{
    public class DepartmentVM
    {
        public int Department_Id { get; set; }
        [Required(ErrorMessage = "Department Name Is Required")]
        [MaxLength(30, ErrorMessage = "Max Length 30 char")]
        [MinLength(2, ErrorMessage = "Min Length 2 char ")]
        public string Department_Name { get; set; }
        [Required(ErrorMessage = "Department Code Is Required")]
        [MaxLength(30, ErrorMessage = "Max Length 30 char")]
        [MinLength(2, ErrorMessage = "Min Length 2 char ")]
        public string Department_Code { get; set; }

        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
