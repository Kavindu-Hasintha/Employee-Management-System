namespace NewCrud.Dto
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<DepartmentDto, Department>();
            CreateMap<EmployeeRegisterDto, Employee>();
        }
    }
}
