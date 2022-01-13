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

        public List<vwCandidate> vwUsers()
        {
            List<vwCandidate> vwCandidates = new List<vwCandidate>();
            vwCandidates = _context.Candidates.Select(u => new vwCandidate()
            {
                FirtsName = u.FirstName,
                LastName = u.LastName,
                Age = u.Age,
                Gender = u.Gender,
            }).ToList();
            return vwCandidates;
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
    }
}
