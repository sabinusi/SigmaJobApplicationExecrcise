using CsvHelper.Configuration;
namespace SigmaJobApplicantion.Model;

public class ApplicantMap:ClassMap<Applicant>
{
    public ApplicantMap()
    {
        Map(m => m.FirstName).Name("FirstName");
        Map(m => m.LastName).Name("LastName");
        Map(m => m.Email).Name("Email");
        Map(m => m.CallTime).Name("CallTime");
        Map(m => m.PhoneNumber).Name("PhoneNumber");
        Map(m => m.LinkedInProfileLink).Name("LinkedAccount");
        Map(m => m.GitHubProfileLink).Name("GitHubAccount");
        Map(m => m.FreeText).Name("FreeText");
    }
}