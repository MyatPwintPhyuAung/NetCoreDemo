using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NetCoreDemo.Entities;

[Table("Employee")]
public partial class Employee
{
    [Key]
    [StringLength(50)]
    public string EmployeeId { get; set; } = null!;

    [StringLength(256)]
    public string? EmployeeName { get; set; }

    public DateOnly? JoinDate { get; set; }

    [StringLength(50)]
    public string? PhoneNumber { get; set; }

    public string? DetailAddress { get; set; }

    [StringLength(50)]
    public string? Gender { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    [StringLength(256)]
    public string? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedOn { get; set; }

    [StringLength(256)]
    public string? UpdatedBy { get; set; }
}
