namespace Project.DAL.Entities
{
    public class Country
    {
        public int Country_Id { get; set; }

        public string? Country_Name { get; set; }

        public List<City>? Cities { get; set; }
    }
}
