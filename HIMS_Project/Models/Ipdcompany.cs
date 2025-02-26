using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HIMS_Project.Models;

[Table("ipdcompanies")]
public partial class Ipdcompany
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [InverseProperty("Company")]
    public virtual ICollection<Ipdservicecompanyrate> Ipdservicecompanyrates { get; set; } = new List<Ipdservicecompanyrate>();
}
