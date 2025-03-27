using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HIMS_Project.Models;

[Table("ipdservicecategories")]
[Index("Srno", Name = "UQ__ipdservi__36B150C79FD6A295", IsUnique = true)]
public partial class Ipdservicecategory
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Column("srno")]
    public int Srno { get; set; }

    [InverseProperty("Ipdservicecategory")]
    public virtual ICollection<Ipdservice> Ipdservices { get; set; } = new List<Ipdservice>();


}
