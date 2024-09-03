using System.ComponentModel.DataAnnotations;

namespace Project.BLL.Model
{
    public class EmployeeVM
    {
        public EmployeeVM()
        {
            IsActive = true;
            CreationDate = DateTime.Now;
        }
        public int Employee_Id { get; set; }

        [Required(ErrorMessage = "First Name Is Required")]
        public string? Employee_Fname { get; set; }

        [Required(ErrorMessage = "Last Name Is Required")]
        public string? Employee_Lname { get; set; }

        [EmailAddress(ErrorMessage = "Email not valid")]
        public string? Employee_Email { get; set; }

        // 01143254939
        [RegularExpression("[0-9]{11}", ErrorMessage = "Enter Like This 01143254939")]
        public string? Employee_Phone { get; set; }

        // 176-Streetname-City-Country
        //[RegularExpression("[1-9]{1,4}-[a-zA-Z]{1-30}-[a-zA-Z]{1-20}-[a-zA-Z]{1-20}", ErrorMessage = "Enter Like This 176-Streetname-City-Country")]
        public string? Address { get; set; }

        public double Employee_Salary { get; set; }

        [Required(ErrorMessage = "HireDate Is Required")]
        public DateTime HireDate { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsUpdated { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime DeletedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int? Department_Id { get; set; }

        public Department? Department { get; set; }
    }
}
