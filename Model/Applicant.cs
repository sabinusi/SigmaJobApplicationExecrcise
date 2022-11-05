using System.ComponentModel.DataAnnotations;

namespace SigmaJobApplicantion.Model;

public class Applicant
{
 
    [Required]
    [StringLength(40,MinimumLength = 3,ErrorMessage = "Too short")]
    public string FirstName { get; set; }
    
    

    [Required]
    [StringLength(40,MinimumLength = 3,ErrorMessage = "Too short")]
    public string LastName { get; set; }
    
   
    
    [RegularExpression(@"^\s*(?:\+?(\d{1,3}))?[-. (]*(\d{3})[-. )]*(\d{3})[-. ]*(\d{4})(?: *x(\d+))?\s*$",ErrorMessage = "Invalid phone number")]
    public string PhoneNumber { get; set; }
    
    

    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    
  
    
    [RegularExpression(@"^\d{2}[: ]*\d{2}((am|AM)|(PM|pm))$",ErrorMessage = "invalid call time")]
    public string CallTime { get; set; }
    

    [RegularExpression(@"^((http|https)://)?(www.linkedin.com/)+[a-z]+(/)+[a-zA-Z0-9-]{5,30}$",ErrorMessage = "Invalid linked in account")]
    public string LinkedInProfileLink { get; set; }
    
    
  
    [RegularExpression(@"^(https?://)?(www.)?github.com/[a-zA-Z0-9_]{1,25}",ErrorMessage = "Invalid github accunt")]
    public string GitHubProfileLink { get; set; }

 
    [Required]
    [StringLength(500,MinimumLength = 10,ErrorMessage = "Too short")]
    public string FreeText { get; set; }
}