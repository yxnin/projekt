using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Core.Entities;

public class Patient : Person
{
    public DateOnly? BirthDate { get; set; }
}
