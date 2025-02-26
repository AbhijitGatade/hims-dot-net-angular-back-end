using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HIMS_Project.Models;

[Table("menus")]
public partial class Menu
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("title")]
    [StringLength(200)]
    public string? Title { get; set; }

    [Column("link")]
    [StringLength(100)]
    public string? Link { get; set; }

    [Column("srno")]
    public int? Srno { get; set; }

    [Column("isparentmenu")]
    [StringLength(200)]
    public string? Isparentmenu { get; set; }

    [Column("parentmenuid")]
    public int? Parentmenuid { get; set; }

    [InverseProperty("Menu")]
    public virtual ICollection<RoleMenu> RoleMenus { get; set; } = new List<RoleMenu>();
}
