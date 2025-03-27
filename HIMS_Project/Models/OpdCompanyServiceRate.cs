using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HIMS_Project.Models
{
    [Table("opd_company_service_rates")]
    public class OpdCompanyServiceRate
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("companyid")]
        public int companyid { get; set; }

        [Column("serviceid")]
        public int serviceid { get; set; }

        [Column("doctorid")]
        public int doctorid { get; set; }

        [Column("rate")]
        public double rate { get; set; }

        [Column("frate")]
        public double frate { get; set; }


        [ForeignKey("serviceid")]
        [InverseProperty("OpdCompanyServiceRates")]
        public virtual Opdservice? Opdservice { get; set; }

        [ForeignKey("doctorid")]
        [InverseProperty("OpdCompanyServiceRates")]
        public virtual Doctor? Doctor { get; set; }

        [ForeignKey("companyid")]
        [InverseProperty("OpdCompanyServiceRates")]
        public virtual Company? Company { get; set; }
    }
}
