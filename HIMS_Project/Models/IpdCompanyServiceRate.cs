using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HIMS_Project.Models
{
    [Table("ipd_company_service_rates")]
    public class IpdCompanyServiceRate
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("companyid")]
        public int companyid { get; set; }

        [Column("serviceid")]
        public int serviceid { get; set; }

        [Column("rate")]
        public double rate { get; set; }
        
        [ForeignKey("serviceid")]
        [InverseProperty("IpdCompanyServiceRates")]
        public virtual Ipdservice? Ipdservice { get; set; } 

        [ForeignKey("companyid")]
        [InverseProperty("IpdCompanyServiceRates")]
        public virtual Company? Company { get; set; }
    }
}
