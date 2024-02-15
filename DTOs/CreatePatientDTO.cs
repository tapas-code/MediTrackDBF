namespace DemoAppDBF.DTOs
{
    public class CreatePatientDTO
    {
        public required string Mrn { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required DateTime Dob { get; set; }

        public required string Gender { get; set; }
    }
}
