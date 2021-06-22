using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebApp.DAL.DBO
{
    public class Employee
    {
        [DisplayName("Id")]
        public int EmployeeId { get; set; }

        [Required]
        [MinLength(4)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(4)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public decimal Salary { get; set; }

        [Required]
        public string Email { get; set; }

        [Display(Name = "Employee Photo")]
        public byte[] EmpPhotoBinary { get; set; }

        [Display(Name = "Photo")]
        [DataType(DataType.Upload)]
        [NotMapped]
        public IFormFile EmpPhoto { get; set; }

        public bool IsFullTime { get; set; }

        [Required]
        [Display(Name = "Branch")]
        public int BranchId { get; set; }

        public Branch Branch { get; set; }
    }
}
