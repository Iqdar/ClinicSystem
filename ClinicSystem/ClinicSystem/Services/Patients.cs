using ClinicSystem.IServices;
using ClinicSystem.Models;

namespace ClinicSystem.Services
{
    public class Patients : GenericRepository<Patient>, IPatients
    {
        public Patients(ClinicSystemContext context) : base(context)
        {

        }
    }
}
