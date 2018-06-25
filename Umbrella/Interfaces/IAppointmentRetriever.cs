using Umbrella.Models;

namespace Umbrella.Interfaces
{
    public interface IAppointmentNewRetriever
    {
        AppointmentStoreNew GetNewAppointment();
    }
}
