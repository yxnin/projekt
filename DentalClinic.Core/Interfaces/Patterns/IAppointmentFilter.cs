using System.Linq.Expressions;
using DentalClinic.Core.Entities;

namespace DentalClinic.Core.Interfaces.Patterns;

public interface IAppointmentFilter
{
    Expression<Func<Appointment, bool>> ToExpression();
}
