namespace Project.DAL.Entities
{
    public class City
    {
        public int City_Id { get; set; }

        public string? City_Name { get; set; }

        public int? Country_Id { get; set; }

        public List<District>? Districts { get; set; }

        public Country? Country { get; set; }
    }
}
