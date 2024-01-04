using ClinicSystem.IServices;
using ClinicSystem.Models;

namespace ClinicSystem.Services
{
    public class Doctors : GenericRepository<Doctor>, IDoctors
    {
        public Doctors(ClinicSystemContext context) : base(context)
        {

        }
    }
}
