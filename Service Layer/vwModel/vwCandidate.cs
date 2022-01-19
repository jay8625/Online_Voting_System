using System.ComponentModel.DataAnnotations;

namespace Service_Layer.vwModel
{
    public class vwCandidate
    {
        [Display(Name = "Candidate Id")]
        public int CandidateId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Votes Achived")]
        public int VotesAchived { get; set; }
    }
}
