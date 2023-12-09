namespace NewCrud.Dto
{
    public class EmployeeRegisterDto
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required, DataType(DataType.Date)]
        public DateTime dateofjoining { get; set; }
    }
}
