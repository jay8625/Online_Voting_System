using System;
using System.ComponentModel.DataAnnotations;

namespace Service_Layer.vwModel
{
    public class vwUser 
    {
        [Display(Name = "User Id")]
        public int UserId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Voted To")]
        public int? VoteStatus { get; set; }
        [Display(Name = "Candidate Name")]
        public string CandidateName { get; set; }
        [Display(Name = "Date Time")]
        public DateTime dateTime { get; set; }
    }
    
}
