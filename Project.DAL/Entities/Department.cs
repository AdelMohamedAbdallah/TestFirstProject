﻿namespace Project.DAL.Entities
{
    public class Department
    {
        public int Department_Id { get; set; }

        public string Department_Name { get; set; }

        public string Department_Code { get; set; }

        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
