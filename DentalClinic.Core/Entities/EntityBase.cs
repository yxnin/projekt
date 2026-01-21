using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DentalClinic.Core.Entities;

public abstract class EntityBase
{
    public int Id { get; set; }
    public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
}