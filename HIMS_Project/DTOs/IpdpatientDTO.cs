using HIMS_Project.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HIMS_Project.DTOs
{

    public class IpdpatientDTO
    {
        public int? ipdid { get; set; }

        public int? ipdpatientid { get; set; }

        public DateOnly? Admissiondate { get; set; }

        public string? Admissiontime { get; set; }
        public TimeOnly? AdmissiontimeConverted
        {
            get
            {
                if (TimeOnly.TryParse(Admissiontime, out var time))
                {
                    return time;
                }
                return null;
            }
        }

        public int? ipddoctorid { get; set; }

        public string? Status { get; set; }

        public DateOnly? Dischargedate { get; set; }

        public string? Dischargetime { get; set; }
        public TimeOnly? DischargeTimeConverted
        {
            get
            {
                if (TimeOnly.TryParse(Dischargetime, out var time))
                {
                    return time;
                }
                return null;
            }
        }

        public string? Dischargedas { get; set; }

        public int? Roomid { get; set; }

        public int? Bedid { get; set; }

        public decimal? Totalamount { get; set; }

        public decimal? Discountamount { get; set; }

        public decimal? Billamount { get; set; }

        public decimal? Paidamount { get; set; }

        public int Concessionbyid { get; set; }

      

    }
}
