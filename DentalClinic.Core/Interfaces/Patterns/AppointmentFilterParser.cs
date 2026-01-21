using System.Globalization;
using System.Linq.Expressions;
using DentalClinic.Core.Entities;
using DentalClinic.Core.Interfaces.Patterns;

namespace DentalClinic.Core.Patterns;

/// <summary>
/// Minimalny Interpreter filtrów wizyt, kompatybilny z EF.
/// Obsługa:
/// - status=Scheduled
/// - dentistId=3
/// - patientId=2
/// - date>=2026-01-01 (StartUtc)
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
                expr = expr.AndAlso(a => a.Status == v);
            }
            else if (p.StartsWith("dentistId=", StringComparison.OrdinalIgnoreCase))
            {
                if (int.TryParse(p["dentistId=".Length..].Trim(), out var id))
                    expr = expr.AndAlso(a => a.DentistId == id);
            }
            else if (p.StartsWith("patientId=", StringComparison.OrdinalIgnoreCase))
            {
                if (int.TryParse(p["patientId=".Length..].Trim(), out var id))
                    expr = expr.AndAlso(a => a.PatientId == id);
            }
            else if (p.StartsWith("date>=", StringComparison.OrdinalIgnoreCase))
            {
                var s = p["date>=".Length..].Trim().Trim('"');
                if (DateOnly.TryParseExact(s, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var d))
                {
                    var from = DateTime.SpecifyKind(d.ToDateTime(TimeOnly.MinValue), DateTimeKind.Utc);
                    expr = expr.AndAlso(a => a.StartUtc >= from);
                }
            }
        }

        return new LambdaAppointmentFilter(expr);
    }

    private sealed class LambdaAppointmentFilter : IAppointmentFilter
    {
        private readonly Expression<Func<Appointment, bool>> _expr;
        public LambdaAppointmentFilter(Expression<Func<Appointment, bool>> expr) => _expr = expr;
        public Expression<Func<Appointment, bool>> ToExpression() => _expr;
    }

    private static Expression<Func<T, bool>> AndAlso<T>(
        this Expression<Func<T, bool>> left,
        Expression<Func<T, bool>> right)
    {
        var param = Expression.Parameter(typeof(T), "x");
        var leftBody = new ReplaceParameterVisitor(left.Parameters[0], param).Visit(left.Body)!;
        var rightBody = new ReplaceParameterVisitor(right.Parameters[0], param).Visit(right.Body)!;
        var body = Expression.AndAlso(leftBody, rightBody);
        return Expression.Lambda<Func<T, bool>>(body, param);
    }

    private sealed class ReplaceParameterVisitor : ExpressionVisitor
    {
        private readonly ParameterExpression _from;
        private readonly ParameterExpression _to;

        public ReplaceParameterVisitor(ParameterExpression from, ParameterExpression to)
        {
            _from = from;
            _to = to;
        }

        protected override Expression VisitParameter(ParameterExpression node)
            => node == _from ? _to : base.VisitParameter(node);
    }
}
