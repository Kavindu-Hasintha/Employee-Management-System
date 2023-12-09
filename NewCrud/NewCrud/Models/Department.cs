﻿namespace NewCrud.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public ICollection<Employee> Employees { get; set; }
    }
}
