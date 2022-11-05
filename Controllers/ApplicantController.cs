using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using SigmaJobApplicantion.Helper.Interfaces;
using SigmaJobApplicantion.Model;
using Constants = SigmaJobApplicantion.Helper.Constants;

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
                return Ok(Helper.Constants.UPDATE_APPLICANT_SUCCESFULL);
            }
            else
            {
                _applicantRepository.AddEntity(applicant);
                return Ok(Constants.APPLICANT_ADDED_SUCCESFULL);
          
            }
        }
        catch (Exception exception)
        {
            return BadRequest(exception);
        }
    }

}