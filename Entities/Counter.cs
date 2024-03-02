using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NetCoreDemo.Entities;

[Table("Counter")]
public partial class Counter
{
    [Key]
    public int CounterId { get; set; }

    [StringLength(50)]
    public string? CounterName { get; set; }
}
