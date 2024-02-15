namespace DemoAppDBF.DTOs
{
    public class GetPatientsDTO
    {

        public required string Mrn { get; set; }

        public required string PatientName { get; set; }

        public required DateTime Dob { get; set; }

        public required string Gender { get; set; }

    }
}
