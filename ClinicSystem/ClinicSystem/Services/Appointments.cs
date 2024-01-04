using ClinicSystem.IServices;
using ClinicSystem.Models;

namespace ClinicSystem.Services
{
    public class Appointments : GenericRepository<Appointment>, IAppointments
    {
        public Appointments(ClinicSystemContext context) : base(context)
        {

        }
    }
}
