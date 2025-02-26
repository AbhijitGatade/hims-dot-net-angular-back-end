using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HIMS_Project.Models;

[Table("h_information")]
public partial class HInformation
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("ikey")]
    public string? Ikey { get; set; }

    [Column("ivalue")]
    public string? Ivalue { get; set; }
}
