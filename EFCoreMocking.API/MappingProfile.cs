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
            CreateMap<Employee, EmployeeDto>();
			CreateMap<EmployeeForCreationDto, Employee>();
            CreateMap<EmployeeForUpdateDto, Employee>();
        }
	}
}

