using System;
using System.Collections.Generic;

namespace ClinicSystem.Models;

public partial class Appointment
{
    public int Id { get; set; }

    public DateTime? DateAndTime { get; set; }

    public bool WasPresent { get; set; }

    public int? PatientId { get; set; }

    public int? DoctorId { get; set; }

    public virtual Doctor? Doctor { get; set; }

    public virtual Patient? Patient { get; set; }
}
