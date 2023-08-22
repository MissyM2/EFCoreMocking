using System;
using System.ComponentModel.DataAnnotations;

namespace EFCoreMocking.API.Entities.DataTransferObjects
{
	public class EmployeeForCreationDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public String Email { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [Phone]
        public string? Phone { get; set; }
    }
}

