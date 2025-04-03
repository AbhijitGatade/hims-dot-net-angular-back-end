using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HIMS_Project.Models;

[Table("paymentmodes")]
[Index("Name", Name = "UQ__paymentm__72E12F1B02141538", IsUnique = true)]
public partial class Paymentmode
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [InverseProperty("Paymentmethod")]
    public virtual ICollection<Ipdbillpayment>? Ipdbillpayments { get; set; } = new List<Ipdbillpayment>();

    [InverseProperty("Paymentmode")]
    public virtual ICollection<Opdbillpayment>? Opdbillpayments { get; set; } = new List<Opdbillpayment>();

    [InverseProperty("Paymentmodes")]
    public virtual ICollection<Opdbill>? Opdbills { get; set; } = new List<Opdbill>();
}
