namespace ClinicSystem.Models.ViewModels
{
    public class AppointmentViewModel
    {
        public Appointment Appointment { get; set; }
        public IEnumerable<Doctor> Doctors
        { get; set; }
    }
}
