using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DemoAppDBF.Models;

public partial class MedicalChart
{
    public int ChartId { get; set; }

    public int PatientId { get; set; }

    public required string ChartType { get; set; }

    public required string ChartUrl { get; set; }

    [JsonIgnore]
    public virtual Patient? Patient { get; set; }
}
