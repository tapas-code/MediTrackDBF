namespace DemoAppDBF.DTOs
{
    public class GetPatientDTO
    {
        public int PatientId { get; set; }

        public required string Mrn { get; set; }

        //public required string FirstName { get; set; }

        //public required string LastName { get; set; }

        public required string PatientName { get; set; }

        //public required DateTime Dob { get; set; }

        //public required string Gender { get; set; }

        //public required List<MedicalChartDTO> MedicalCharts { get; set; }
    }
}
