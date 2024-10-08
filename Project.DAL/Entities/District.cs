using System.Text.Json.Serialization;

namespace Project.DAL.Entities
{
    public class District
    {
        public int District_Id { get; set; }

        public string? District_Name { get; set; }

        public int? City_Id { get; set; }

        public City? City { get; set; }

        [JsonIgnore]
        public List<Employee>? Employees { get; set; }
    }
}
