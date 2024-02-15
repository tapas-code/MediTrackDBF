using System;
using System.Collections.Generic;

namespace DemoAppDBF.Models;

public partial class Patient
{
    public int PatientId { get; set; }

    public required string Mrn { get; set; }

    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public string PatientName { get; set; } = string.Empty;

    public required DateTime Dob { get; set; }

    public required string Gender { get; set; }

    public virtual ICollection<MedicalChart> MedicalCharts { get; set; } = new List<MedicalChart>();
}
