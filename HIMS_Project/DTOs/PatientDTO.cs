using HIMS_Project.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace HIMS_Project.DTOs
{
    public class PatientDTO
    {
        public int patientid { get; set; }
        public Patient patient { get; set; }
        public string ptype { get; set; }
        public Opdpatient opd { get; set; }
        public Ipdpatient ipd { get; set; }

    }
}
