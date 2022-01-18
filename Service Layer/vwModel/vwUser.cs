using System;
using System.ComponentModel.DataAnnotations;

namespace Service_Layer.vwModel
{
    public class vwUser 
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? VoteStatus { get; set; }
        public string CandidateName { get; set; }
        [Display(Name = "Date Time")]
        public DateTime dateTime { get; set; }
    }
    
}
