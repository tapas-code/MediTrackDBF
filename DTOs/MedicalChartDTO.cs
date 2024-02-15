namespace DemoAppDBF.DTOs
{
    public class MedicalChartDTO
    {
        public int ChartID { get; set; }
        public int PatientID { get; set; }
        public required string ChartType { get; set; }
        public required string ChartURL { get; set; }
    }
}
