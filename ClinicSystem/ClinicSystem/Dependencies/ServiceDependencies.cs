using ClinicSystem.IServices;
using ClinicSystem.Services;

namespace ClinicSystem.Dependencies
{
    public static class ServiceDependencies
    {
        public static void AddServicesDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IPatients, Patients>();
            services.AddScoped<IDoctors, Doctors>();
            services.AddScoped<IAppointments, Appointments>();

        }
    }
}
