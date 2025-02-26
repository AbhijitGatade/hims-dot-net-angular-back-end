using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HIMS_Project.Models;

[Table("opdservices")]
public partial class Opdservice
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("srno")]
    public int Srno { get; set; }

    [Column("name")]
    [StringLength(255)]
    public string Name { get; set; } = null!;

    [Column("rate")]
    public double Rate { get; set; }

    [Column("frate")]
    public double Frate { get; set; }

    [Column("opdservicecategoryid")]
    public int Opdservicecategoryid { get; set; }

    [InverseProperty("Opdservice")]
    public virtual ICollection<Opdbillservice> Opdbillservices { get; set; } = new List<Opdbillservice>();

    [ForeignKey("Opdservicecategoryid")]
    [InverseProperty("Opdservices")]
    public virtual Opdservicecategory? Opdservicecategory { get; set; }
}
