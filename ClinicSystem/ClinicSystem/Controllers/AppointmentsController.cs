using ClinicSystem.IServices;
using ClinicSystem.Models;
using ClinicSystem.Models.ViewModels;
using ClinicSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace ClinicSystem.Controllers
{
    public class AppointmentsController : Controller
    {
        private IAppointments _appointments;
        private IDoctors _doctors;

        public AppointmentsController(IAppointments appointments, IDoctors doctors)
        {
            _appointments = appointments;
            _doctors = doctors;

        }

        public IActionResult Index()
        {
            dynamic ExpObj = new ExpandoObject();
            ExpObj.appointmentsList = _appointments.GetAll();
            return View(ExpObj);
        }

        public IActionResult _List()
        {
            dynamic ExpObj = new ExpandoObject();
            ExpObj.appointmentsList = _appointments.GetAll().ToList();
            return PartialView(ExpObj);
        }

        public IActionResult Add(int Id)
        {
            AppointmentViewModel model = new AppointmentViewModel {
                Appointment = new Appointment { PatientId = Id},
                Doctors = _doctors.GetAll().ToList(),
            };
            return View("AppointmentForm", model);
        }
        public IActionResult Edit(int id)
        {

            AppointmentViewModel model = new AppointmentViewModel
            {
                Appointment = _appointments.GetById(id),
                Doctors = _doctors.GetAll().ToList(),
            };
            return View("AppointmentForm", model);
        }

        public IActionResult Save(Appointment appointment)
        {
            string err = "";
            if (appointment.Id == 0)
            {
                err = _appointments.Insert(appointment);
                if (string.IsNullOrEmpty(err))
                {
                    _appointments.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            else
            {
                err = _appointments.Update(appointment);
                if (string.IsNullOrEmpty(err))
                {
                    _appointments.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View("AppointmentForm", appointment);
        }
    }
}
