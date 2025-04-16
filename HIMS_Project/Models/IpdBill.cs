using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HIMS_Project.Models
{
    [Table("ipdbills")]
    public class IpdBill
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("ipdid")]
        public int Ipdid { get; set; }

        [Column("serviceid")]
        public int Serviceid { get; set; }

        [Column("rate")]
        public string Rate { get; set; }

        [Column("quantity")]
        public int? Quantity { get; set; }

        [Column("remark")]
        public string? Remark { get; set; }

        [Column("total")]
        public double? Total { get; set; }


        //[ForeignKey("ipdid")]
        //[InverseProperty("IpdBill")]
        //public virtual Ipdpatient? Ipdpatient { get; set; } = null!;

        //[ForeignKey("serviceid")]
        //[InverseProperty("IpdBill")]
        //public virtual Ipdservice? Ipdservice { get; set; } = null!;

    }
}
