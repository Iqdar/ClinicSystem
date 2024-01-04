using System;
using System.Collections.Generic;

namespace ClinicSystem.Models;

public partial class Doctor
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
