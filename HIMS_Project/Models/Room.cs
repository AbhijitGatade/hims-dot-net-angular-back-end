using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HIMS_Project.Models;

[Table("rooms")]
public partial class Room
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(200)]
    public string Name { get; set; } = null!;

    [Column("prefix")]
    [StringLength(50)]
    public string? Prefix { get; set; }

    [Column("oColor")]
    public string OColor { get; set; } = null!;

    [Column("vColor")]
    public string VColor { get; set; } = null!;

    [InverseProperty("Room")]
    public virtual ICollection<Bed> Beds { get; set; } = new List<Bed>();

    [InverseProperty("Room")]
    public virtual ICollection<Ipdpatient> Ipdpatients { get; set; } = new List<Ipdpatient>();
}
