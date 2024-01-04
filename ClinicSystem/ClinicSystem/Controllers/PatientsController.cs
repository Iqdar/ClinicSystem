using ClinicSystem.IServices;
using ClinicSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;

namespace ClinicSystem.Controllers
{
    public class PatientsController : Controller
    {
        private IPatients _patients;

        public PatientsController(IPatients patients)
        {
            _patients = patients;
        }

        public IActionResult Index()
        {
            dynamic ExpObj = new ExpandoObject();
            ExpObj.patientsList = _patients.GetAll();
            return View(ExpObj);
        }

        public IActionResult _List()
        {
            dynamic ExpObj = new ExpandoObject();
            ExpObj.patientsList = _patients.GetAll().ToList();
            return PartialView(ExpObj);
        }

        public IActionResult Add()
        {
            Patient patient = new Patient();
            return View("PatientForm", patient);
        }
        public IActionResult Edit(int id)
        {
            var patient = _patients.GetById(id);
            return View("PatientForm", patient);
        }

        public IActionResult Save(Patient patient)
        {
            string err = "";
            if (patient.Id == 0)
            {
                err = _patients.Insert(patient);
                if (string.IsNullOrEmpty(err))
                {
                    _patients.SaveChanges();
                    return RedirectToAction("Index");
                }
                
            }
            else
            {
                err = _patients.Update(patient);
                if (string.IsNullOrEmpty(err))
                {
                    _patients.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View("PatientForm", patient);
        }
        /*
        private readonly ClinicSystemContext _context;

        public PatientsController(ClinicSystemContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var patients = _context.Patients.ToList();
            return View(patients);
        }
        public IActionResult Add()
        {
            Patient patient = new Patient();
            return View(patient);
        }
        public IActionResult Update(int id)
        {
            var patient = _context.Patients.SingleOrDefault(p => p.Id == id);
            return View(patient);
        }
        public IActionResult Save(Patient patient)
        {
            if (patient.Id ==0)
            {
                _context.Patients.Add(patient);
            }
            else
            {
                var patientInDb = _context.Patients.Single(p => p.Id == patient.Id);
                patientInDb.Name = patient.Name;
                patientInDb.DateOfBirth = patient.DateOfBirth;
                patientInDb.Gender = patient.Gender;
            }
            _context.SaveChanges();
            return View();
        }*/
    }
}
