using System.ComponentModel.DataAnnotations;

namespace JobAppTracker.Models;

public class JobApp
{
    [Key]
    public int Id {get; set;}

    public string userId {get; set;}
    [Required]
    public string CompanyName {get; set;}
    [Required]
    public string Position {get; set;}
    [Required]
    public string Status {get; set;}

    public string Link {get; set;}

    public string Resume {get; set;}

    public DateTime DateApplied {get; set;}

}
