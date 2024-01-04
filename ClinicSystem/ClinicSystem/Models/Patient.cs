using System;
using System.Collections.Generic;

namespace ClinicSystem.Models;

public partial class Patient
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Gender { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}

public enum SelectGender
{
    Male,
    Female
}