using tutorial04.Models;

namespace tutorial04.DataStores;

public class AppointmentDataStore
{
    public List<Appointment> Appointments { get; set; }

    public static AppointmentDataStore Current { get; } = new AppointmentDataStore();

    public AppointmentDataStore()
    {
        Appointments = new List<Appointment>();
    }
    
}