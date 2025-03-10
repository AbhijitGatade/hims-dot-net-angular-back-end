using HIMS_Project.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace HIMS_Project.DTOs
{
    public class PatientDTO
    {

        public int Id { get; set; }

        public string? Prefix { get; set; } = null!;

        public string? Name { get; set; } = null!;

        public string? Uidno { get; set; } = null!;

        public DateOnly Birthdate { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; } = null!;

        public string? BloodGroup { get; set; }

        public string address { get; set; } 

        public int townid { get; set; } 

        public string? MobileNo { get; set; } = null!;

        public string? AltMobileNo { get; set; }

        public string? MaritalStatus { get; set; }

        public string? Occupation { get; set; }

        public string? AadhaarNo { get; set; }

        public int Createdby { get; set; }

        public int? Updatedby { get; set; }

        public DateTime? Createdon { get; set; }

        public DateTime? Updatedon { get; set; }

    }
}
