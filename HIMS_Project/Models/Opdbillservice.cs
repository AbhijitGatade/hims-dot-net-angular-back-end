using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HIMS_Project.Models;

[Table("opdbillservices")]
public partial class Opdbillservice
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("billid")]
    public int Billid { get; set; }

    [Column("opdserviceid")]
    public int Opdserviceid { get; set; }

    [Column("doctorid")]
    public int Doctorid { get; set; }

    [Column("concdiscount")]
    public int Concdiscount { get; set; }

    [Column("totalamount")]
    public double Totalamount { get; set; }

    [Column("discountamount")]
    public double? Discountamount { get; set; }

    [Column("billamount")]
    public double Billamount { get; set; }

    [ForeignKey("Billid")]
    [InverseProperty("Opdbillservices")]
    public virtual Opdbill? Bill { get; set; } = null!;

    [ForeignKey("Opdserviceid")]
    [InverseProperty("Opdbillservices")]
    public virtual Opdservice? Opdservice { get; set; } = null!;


    //[ForeignKey("doctorid")]
    //[InverseProperty("Opdbillservices")]
    //public virtual Doctor? Doctor { get; set; } = null!;
}
