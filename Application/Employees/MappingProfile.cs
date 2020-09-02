using AutoMapper;
using Domain;

namespace Application.Employees
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeesReturnDto>()
                .ForMember(x => x.Department,
                    o => o.MapFrom(x => x.Department.Name));
        }
    }
}