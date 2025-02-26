using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HIMS_Project.Models;

[Table("concession_by")]
public partial class ConcessionBy
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [InverseProperty("Concessionby")]
    public virtual ICollection<Ipdpatient> Ipdpatients { get; set; } = new List<Ipdpatient>();

    [InverseProperty("Concessionby")]
    public virtual ICollection<Opdbill> Opdbills { get; set; } = new List<Opdbill>();

    internal bool Any()
    {
        throw new NotImplementedException();
    }
}
