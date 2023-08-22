using System;
using AutoMapper;
using EFCoreMocking.API.Entities.DataTransferObjects;
using EFCoreMocking.API.Entities.Models;

namespace EFCoreMocking.API
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
            CreateMap<Employee, EmployeeDto>().ReverseMap();
			CreateMap<EmployeeForCreationDto, Employee>().ReverseMap();
            CreateMap<EmployeeForUpdateDto, Employee>().ReverseMap();
        }
	}
}

