using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HIMS_Project.DTOs;
using Microsoft.EntityFrameworkCore;

namespace HIMS_Project.Models;

[Table("beds")]
public partial class Bed
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(100)]
    public string? Name { get; set; }

    [Column("roomid")]
    public int Roomid { get; set; }

    [InverseProperty("Bed")]
    public virtual ICollection<Ipdpatient> Ipdpatients { get; set; } 

    [ForeignKey("Roomid")]
    [InverseProperty("Beds")]
    public virtual Room? Room { get; set; } = null!;
}
