using System.ComponentModel.DataAnnotations;

namespace Project.BLL.Model
{
    public class EmailVM
    {
        [Required(ErrorMessage = "Title is required")]
        [MaxLength(50, ErrorMessage = "Max Length 50 char")]
        public string Title { get; set; }

        public string Message { get; set; }
    }
}
