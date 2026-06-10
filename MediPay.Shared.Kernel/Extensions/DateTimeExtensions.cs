using System.Runtime.CompilerServices;

namespace MediPay.Shared.Kernel.Extensions;

public static class DateTimeExtensions
{
    public static string ToShamsi(this DateTime date)
    {
        var calender = new System.Globalization.PersianCalendar();
        return $"{calender.GetYear(date)}/{calender.GetMonth(date):00}/{calender.GetDayOfMonth(date):00}";
    }
    public static string? ToShamsi(this DateTime? date) => date.HasValue ? date.Value.ToShamsi() : "-";

    public static DateTime ToMiladi(this string persianDate)
    {
        if (string.IsNullOrWhiteSpace(persianDate)) throw new ArgumentException("تاریخ نمی تواند خالی باشد.");

        var parts = persianDate.Split('/');

        if (parts.Length != 3) throw new ArgumentException($"فرمت تاریخ {persianDate} معتبر نیست، فرمت صحیح : 1300/01/01");
        if (!int.TryParse(parts[0], out int year) ||
            !int.TryParse(parts[1], out int month) ||
            !int.TryParse(parts[2], out int day))
            throw new ArgumentException($"تاریخ {persianDate} معتبر نیست.");

        var calender = new System.Globalization.PersianCalendar();
        return calender.ToDateTime(year, month, day, 0, 0, 0, 0);
    }
    public static DateTime? ToMiladiOrNull(this string? persianDate)
    {
        if (string.IsNullOrWhiteSpace(persianDate)) return null;
        return persianDate.ToMiladi();
    }

    public static bool IsPast(this DateTime date) => date < DateTime.UtcNow;
    public static bool IsFuture(this DateTime date) => date > DateTime.UtcNow;

    public static int DaysUntil(this DateTime date) => (date - DateTime.UtcNow).Days;
    public static int DaysAgo(this DateTime date) => (DateTime.UtcNow - date).Days;
}
