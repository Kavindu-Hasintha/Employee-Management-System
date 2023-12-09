namespace NewCrud.Dto
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<DepartmentRegisterDto, Department>();
            CreateMap<EmployeeRegisterDto, Employee>();
        }
    }
}
