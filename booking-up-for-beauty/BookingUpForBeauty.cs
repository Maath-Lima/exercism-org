using System;
using System.Globalization;
using System.Threading;

static class Appointment
{
    private const string DATE_FORMAT = "G";

    public static DateTime Schedule(string appointmentDateDescription) => DateTime.ParseExact(appointmentDateDescription
                                                                                              ,new string[] {"M/dd/yyyy HH:mm:ss", "MMMM d, yyyy HH:mm:ss",    "dddd, MMMM d, yyyy HH:mm:ss"}
                                                                                              ,CultureInfo.CurrentCulture,
                                                                                              DateTimeStyles.None);

    public static bool HasPassed(DateTime appointmentDate) => appointmentDate <= DateTime.Now;

    public static bool IsAfternoonAppointment(DateTime appointmentDate) => (appointmentDate.TimeOfDay >= new TimeSpan(12, 0, 0) &&
                                                                            appointmentDate.TimeOfDay < new TimeSpan(18, 0, 0));

    public static string Description(DateTime appointmentDate) => $"You have an appointment on {appointmentDate.ToString(DATE_FORMAT)}.";

    public static DateTime AnniversaryDate() => new DateTime(DateTime.Now.Year, 9, 15, 0, 0, 0);
}
