using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HIMS_Project.Models;
[Table("role_menus")]
public partial class RoleMenu
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("roleid")]
    [Required(ErrorMessage = "RoleId is required.")]
    public int Roleid { get; set; }

    [Column("menuid")]
    [Required(ErrorMessage = "MenuId is required.")]
    public int Menuid { get; set; }

    [ForeignKey("Menuid")]
    [InverseProperty("RoleMenus")]
    public virtual Menu? Menu { get; set; }

    [ForeignKey("Roleid")]
    [InverseProperty("RoleMenus")]
    public virtual Role? Role { get; set; }
}
