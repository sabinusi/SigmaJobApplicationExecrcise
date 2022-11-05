using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using SigmaJobApplicantion.Helper.Interfaces;
using SigmaJobApplicantion.Model;

namespace SigmaJobApplicantion.Controllers;
[ApiController]
[Route("[controller]")]
public class ApplicantController : ControllerBase
{
    private readonly IApplicantRepository _applicantRepository;
    public ApplicantController(IApplicantRepository applicantRepository)
    {
        _applicantRepository = applicantRepository;
    }
    

    [HttpPost]
    
    public  IActionResult AddOrUpdateApplicant(Applicant applicant)
    {
        try
        {
            if (_applicantRepository.UpdateEnttity(applicant))
            {
                return Ok("succesfull updated applicant");
            }
            else
            {
                _applicantRepository.AddEntity(applicant);
                return Ok("succesfull add applicant");
          
            }
        }
        catch (Exception exception)
        {
            return BadRequest(exception);
        }
    }

}