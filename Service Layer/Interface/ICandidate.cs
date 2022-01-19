using DAL_Data_Access_Layer_.Model;
using Service_Layer.vwModel;
using System.Collections.Generic;

namespace Service_Layer.Repositories
{
    public interface ICandidate
    {
        //get all candidates
        IEnumerable<Candidate> GetAll();
        //get candidates as per vwModel
        IEnumerable<vwCandidate> vwCandidates();
        //adds candidate
        void Add(Candidate candidate);
        //update info
        void Update(Candidate candidate);
        //condition by Id
        bool Any(int Id);
        //get candidate by Id
        Candidate GetByID(int Id);
        //Removes Candidate
        void Remove(int Id);
        //sort candidate by votes
        List<vwCandidate> SortByVote();
    }
}
