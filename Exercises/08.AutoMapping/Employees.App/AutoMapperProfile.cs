namespace Employees.App
{
    using AutoMapper;

    using Employees.Models;
    using Employees.DtoModels;
    using System.Collections.Generic;

    class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();

            CreateMap<Employee, EmployeePersonalDto>();

            CreateMap<Employee, ManagerDto>();
            CreateMap<Employee, ProjectionDto>();
            CreateMap<Employee, List<ProjectionDto>>();
        }
    }
}
 