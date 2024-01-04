using ClinicSystem.IServices;
using ClinicSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace ClinicSystem.Controllers
{
    public class DoctorsController : Controller
    {
        private IDoctors _doctors;

        public DoctorsController(IDoctors doctors)
        {
            _doctors = doctors;
        }

        public IActionResult Index()
        {
            dynamic ExpObj = new ExpandoObject();
            ExpObj.doctorsList = _doctors.GetAll();
            return View(ExpObj);
        }

        public IActionResult _List()
        {
            dynamic ExpObj = new ExpandoObject();
            ExpObj.doctorsList = _doctors.GetAll().ToList();
            return PartialView(ExpObj);
        }

        public IActionResult Add()
        {
            Doctor doctor = new Doctor();
            return View("DoctorForm", doctor);
        }
        public IActionResult Edit(int id)
        {
            var doctor = _doctors.GetById(id);
            return View("DoctorForm", doctor);
        }

        public IActionResult Save(Doctor doctor)
        {
            string err = "";
            if (doctor.Id == 0)
            {
                err = _doctors.Insert(doctor);
                if (string.IsNullOrEmpty(err))
                {
                    _doctors.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            else
            {
                err = _doctors.Update(doctor);
                if (string.IsNullOrEmpty(err))
                {
                    _doctors.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View("DoctorForm", doctor);
        }
    }
}
