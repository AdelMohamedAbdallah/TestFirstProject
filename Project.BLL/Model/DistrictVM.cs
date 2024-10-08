using System.Text.Json.Serialization;

namespace Project.BLL.Model
{
    public class DistrictVM
    {
        public int District_Id { get; set; }

        public string? District_Name { get; set; }

        public int? City_Id { get; set; }

        public City? City { get; set; }

        [JsonIgnore]
        public List<Employee>? Employees { get; set; }
    }
}
