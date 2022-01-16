using DAL_Data_Access_Layer_.Model;
using Service_Layer.vwModel;
using System.Collections.Generic;

namespace Service_Layer.Repositories
{
    public interface ICandidate
    {
        IEnumerable<Candidate> GetAll();
        IEnumerable<vwCandidate> vwCandidates();
        void Add(Candidate candidate);
        void Update(Candidate candidate);
        bool Any(int Id);
        Candidate GetByID(int Id);
        void Remove(int Id);
        IEnumerable<int> votes();
    }
}
