using System.Collections.Generic;

namespace Service_Layer.vwModel
{
    public class vwCandidate
    {
        public int CandidateId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<int> Votes { get; set; }
    }
}
