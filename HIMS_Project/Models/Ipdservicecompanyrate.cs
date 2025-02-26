using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HIMS_Project.Models;

[Table("ipdservicecompanyrates")]
public partial class Ipdservicecompanyrate
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("companyid")]
    public int? Companyid { get; set; }

    [Column("ipdserviceid")]
    public int? Ipdserviceid { get; set; }

    [Column("rate", TypeName = "decimal(10, 2)")]
    public decimal Rate { get; set; }

    [ForeignKey("Companyid")]
    [InverseProperty("Ipdservicecompanyrates")]
    public virtual Ipdcompany? Company { get; set; }

    [ForeignKey("Ipdserviceid")]
    [InverseProperty("Ipdservicecompanyrates")]
    public virtual Ipdservice? Ipdservice { get; set; }
}
