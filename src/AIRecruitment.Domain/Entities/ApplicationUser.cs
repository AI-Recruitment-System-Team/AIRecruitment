using Microsoft.AspNetCore.Identity;
namespace AIRecruitment.Domain.Entities;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string AvatarUrl { get; set; }

    public bool IsActive { get; set; }

    // Navigational Properties

    public CandidateProfile CandidateProfile { get; set; }

    //public List<Job> Jobs { get; set; }

    //public List<Notification> Notifications { get; set; }
}