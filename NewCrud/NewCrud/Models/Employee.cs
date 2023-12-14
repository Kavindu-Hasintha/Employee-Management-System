namespace NewCrud.Models
{
    public class Employee
    {

        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required, DataType(DataType.Date)]
        public DateTime DateOfJoin { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
