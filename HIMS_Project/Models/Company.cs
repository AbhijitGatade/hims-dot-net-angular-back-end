using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HIMS_Project.Models;

[Table("companies")]
public partial class Company
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [InverseProperty("Company")]
    public virtual ICollection<IpdCompanyServiceRate>? IpdCompanyServiceRates { get; set; }

    [InverseProperty("Company")]
    public virtual ICollection<OpdCompanyServiceRate>? OpdCompanyServiceRates { get; set; }

    [InverseProperty("Company")]
    public virtual ICollection<Ipdpatient>? Ipdpatients { get; set; }

    [InverseProperty("Company")]
    public virtual ICollection<Opdpatient>? Opdpatients { get; set; }
}
