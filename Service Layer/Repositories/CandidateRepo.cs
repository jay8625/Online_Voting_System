using DAL_Data_Access_Layer_.Data;
using DAL_Data_Access_Layer_.Model;
using Service_Layer.vwModel;
using System.Collections.Generic;
using System.Linq;

namespace Service_Layer.Repositories
{
    public class CandidateRepo : ICandidate
    {
        private readonly CommonDbContext _context;

        public CandidateRepo(CommonDbContext context)
        {
            _context = context;
        }

        public IEnumerable<vwCandidate> vwCandidates()
        {
            List<int> Vote = new List<int>();
            int CandidateCount = _context.Candidates.Count();
            for (int i = CandidateCount; i >= 1; i--)
            {
                var votes = _context.Users.Where(x => x.ChoiceCandidateId == i).Count();
                Vote.Add(votes);
            }
            Vote.Reverse();
            return _context.Candidates.Select(u => new vwCandidate()
            {
                CandidateId = u.CandidateId,
                FirstName = u.FirstName,
                LastName = u.LastName,
                GainedVotes = Vote.ElementAt(u.CandidateId-1)
            });
        }

        public void Add(Candidate candidate)
        {
            _context.Candidates.Add(candidate);
            _context.SaveChanges();
        }

        public bool Any(int Id)
        {
            if (_context.Candidates.Any(e => e.CandidateId == Id))
            {
                return true;
            }
            return false;
        }

        public IEnumerable<Candidate> GetAll()
        {
            return _context.Candidates.ToList();
        }

        public Candidate GetByID(int Id)
        {
            return _context.Candidates.Where(x => x.CandidateId == Id).FirstOrDefault();
        }

        public void Remove(int Id)
        {
            Candidate Remove = _context.Candidates.Find(Id);
            _context.Candidates.Remove(Remove);
            _context.SaveChanges();
        }

        public void Update(Candidate candidate)
        {
            _context.Entry(candidate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
        public IEnumerable<int> votes()
        {
            List<int> Vote = new List<int>();
            int CandidateCount = _context.Candidates.Count();
            for (int Candidates = CandidateCount; Candidates < 1; Candidates--)
            {
                var votes = _context.Users.Where(x => x.ChoiceCandidateId == Candidates).Count();
                Vote.Add(votes);
            }
            return Vote;
        }
    }
}
