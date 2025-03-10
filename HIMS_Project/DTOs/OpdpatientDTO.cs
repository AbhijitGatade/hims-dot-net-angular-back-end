using HIMS_Project.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HIMS_Project.DTOs
{

    public class OpdpatientDTO
    {
        public int? opdid { get; set; }

        public int? opdpatientid { get; set; }

        public DateOnly? Opddate { get; set; }

        public string? Opdtime { get; set; }
        public TimeOnly? AdmissionTimeConverted
        {
            get
            {
                if (TimeOnly.TryParse(Opdtime, out var time))
                {
                    return time;
                }
                return null;
            }
        }

        public double? Height { get; set; }

        public double? Weight { get; set; }

        public int opddoctorid { get; set; }

        public string? Remark { get; set; }

        public int? opdcreatedby { get; set; }

        public int? opdupdateddby { get; set; }

        public DateTime? OnCreatedon { get; set; }

        public DateTime? OnUpdatedon { get; set; }

        

    }
}
