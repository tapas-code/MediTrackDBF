using DemoAppDBF.DTOs;
using DemoAppDBF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoAppDBF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly MedicalRecordsDbContext _context;

        public PatientsController(MedicalRecordsDbContext context)
        {
            _context = context;
        }

        // Get Method to fetch all Patient Records

        [HttpGet]
        public async Task<ActionResult<List<GetPatientsDTO>>> GetPatients()
        {
            var patients = await _context.Patients
                .Include(p => p.MedicalCharts)
                .Select(p => new GetPatientsDTO
                {
                    Mrn = p.Mrn,
                    PatientName = p.PatientName,
                    Dob = p.Dob,
                    Gender = p.Gender,
                    /*MedicalCharts = p.MedicalCharts.Select(mc => new MedicalChartDTO
                    {
                        ChartID = mc.ChartId,
                        PatientID = mc.PatientId,
                        ChartType = mc.ChartType,
                        ChartURL = mc.ChartUrl
                    }).ToList()*/
                })
                .ToListAsync();
            return Ok(patients);
        }

        // Create a new Patient Record 

        [HttpPost("/CreatePatient")]
        public async Task<ActionResult<CreatePatientDTO>> CreatePatient([FromBody] CreatePatientDTO pDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (pDTO == null)
                return NotFound();

            var newPatient = new Patient
            {
                Mrn = pDTO.Mrn,
                FirstName = pDTO.FirstName,
                LastName = pDTO.LastName,
                Dob = pDTO.Dob,
                Gender = pDTO.Gender
            };

            _context.Patients.Add(newPatient);
            await _context.SaveChangesAsync();

            return Ok(newPatient);
        }
    }
}
