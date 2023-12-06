using Microsoft.EntityFrameworkCore;

namespace NewCrud.Models
{
    public class Employee
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime dateofjoining { get; set; }
        public Department Department { get; set; }
    }
}
