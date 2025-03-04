﻿using System;
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
    public int Roleid { get; set; }

    [Column("menuid")]
    public int Menuid { get; set; }

    [ForeignKey("Menuid")]
    [InverseProperty("RoleMenus")]
    public virtual Menu? Menu { get; set; } = null!;

    [ForeignKey("Roleid")]
    [InverseProperty("RoleMenus")]
    public virtual Role? Role { get; set; } = null!;
}
