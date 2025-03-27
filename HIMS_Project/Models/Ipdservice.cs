using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HIMS_Project.Models;

[Table("ipdservices")]
[Index("Srno", Name = "UQ__ipdservi__36B150C74672F6BC", IsUnique = true)]
public partial class Ipdservice
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Column("ipdservicecategoryid")]
    public int? Ipdservicecategoryid { get; set; }

    [Column("srno")]
    public int Srno { get; set; }

    [Column("defaultrate", TypeName = "decimal(10, 2)")]
    public decimal Defaultrate { get; set; }

    [Column("allowselectdoctor")]
    public bool Allowselectdoctor { get; set; }

    [Column("isitroom")]
    public bool Isitroom { get; set; }

    [Column("changesasperroom")]
    public bool Changesasperroom { get; set; }

    [ForeignKey("Ipdservicecategoryid")]
    [InverseProperty("Ipdservices")]
    public virtual Ipdservicecategory? Ipdservicecategory { get; set; }

    [InverseProperty("Ipdservice")]
    public virtual ICollection<IpdCompanyServiceRate> IpdCompanyServiceRates { get; set; } 
}
