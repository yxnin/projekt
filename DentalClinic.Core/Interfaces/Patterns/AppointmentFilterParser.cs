using System.Globalization;
using System.Linq.Expressions;
using DentalClinic.Core.Entities;
using DentalClinic.Core.Interfaces.Patterns;

namespace DentalClinic.Core.Patterns;

/// <summary>
/// Minimalny Interpreter filtrów wizyt.
/// Obsługa:
/// - status=Scheduled
/// - dentistId=3
/// - patientId=2
/// - date>=2026-01-01 (porównanie po dacie StartUtc)
/// - łączenie: AND
/// </summary>
public static class AppointmentFilterParser
{
    public static IAppointmentFilter Parse(string? input)
    {
        input ??= "";
        input = input.Trim();

        if (string.IsNullOrWhiteSpace(input))
            return new LambdaAppointmentFilter(a => true);

        var parts = input.Split(new[] { "AND" }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        Expression<Func<Appointment, bool>> expr = a => true;

        foreach (var part in parts)
        {
            var p = part.Trim();
            if (p.StartsWith("status=", StringComparison.OrdinalIgnoreCase))
            {
                var v = p["status=".Length..].Trim().Trim('"');
                expr = And(expr, a => a.Status == v);
            }
            else if (p.StartsWith("dentistId=", StringComparison.OrdinalIgnoreCase))
            {
                if (int.TryParse(p["dentistId=".Length..].Trim(), out var id))
                    expr = And(expr, a => a.DentistId == id);
            }
            else if (p.StartsWith("patientId=", StringComparison.OrdinalIgnoreCase))
            {
                if (int.TryParse(p["patientId=".Length..].Trim(), out var id))
                    expr = And(expr, a => a.PatientId == id);
            }
            else if (p.StartsWith("date>=", StringComparison.OrdinalIgnoreCase))
            {
                var s = p["date>=".Length..].Trim().Trim('"');
                if (DateOnly.TryParseExact(s, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var d))
                {
                    var from = d.ToDateTime(TimeOnly.MinValue, DateTimeKind.Utc);
                    expr = And(expr, a => a.StartUtc >= from);
                }
            }
        }

        return new LambdaAppointmentFilter(expr);
    }

    private static Expression<Func<Appointment, bool>> And(
        Expression<Func<Appointment, bool>> left,
        Expression<Func<Appointment, bool>> right)
    {
        var param = Expression.Parameter(typeof(Appointment), "a");
        var body = Expression.AndAlso(
            Expression.Invoke(left, param),
            Expression.Invoke(right, param));
        return Expression.Lambda<Func<Appointment, bool>>(body, param);
    }

    private sealed class LambdaAppointmentFilter : IAppointmentFilter
    {
        private readonly Expression<Func<Appointment, bool>> _expr;
        public LambdaAppointmentFilter(Expression<Func<Appointment, bool>> expr) => _expr = expr;
        public Expression<Func<Appointment, bool>> ToExpression() => _expr;
    }
}
