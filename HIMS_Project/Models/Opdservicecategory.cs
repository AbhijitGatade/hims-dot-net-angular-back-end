using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HIMS_Project.Models;

[Table("opdservicecategories")]
public partial class Opdservicecategory
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(500)]
    public string Name { get; set; } = null!;

    [Column("srno")]
    public int Srno { get; set; }

    [InverseProperty("Opdservicecategory")]
    public virtual ICollection<Opdservice> Opdservices { get; set; } = new List<Opdservice>();
}
