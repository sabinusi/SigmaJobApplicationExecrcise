using Microsoft.AspNetCore.Mvc;

namespace SigmaJobApplicantion.Controllers;
[ApiController]
[Route("[controller]")]
public class ApplicantController : ControllerBase
{
    [HttpGet]
    public IActionResult Index()
    {
        return Ok("applicant controller");
    }
}