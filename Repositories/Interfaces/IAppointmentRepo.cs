using HMS.Data.Models;
using HMS.Repositories.GenericRepo;

namespace HMS.Repositories.Interfaces
{
    public interface IAppointmentRepo : IGenericRepo<Appointment>
    {
        Task<IEnumerable<Appointment>> GetAllAppointmentsInfoAsync();
    }
}
