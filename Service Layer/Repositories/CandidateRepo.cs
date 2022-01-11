using DAL_Data_Access_Layer_.Data;
using DAL_Data_Access_Layer_.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service_Layer.Repositories
{
    public class CandidateRepo : ICandidate
    {
        private readonly CommonDbContext _Context;
        public void Add(Candidate candidate)
        {
            _Context.Candidates.Add(candidate);
        }

        public bool Any(int Id)
        {
            if (_Context.Candidates.Any(e => e.CandidateId == Id))
            {
                return true;
            }
            return false;
        }

        public IEnumerable<Candidate> GetAll()
        {
            return _Context.Candidates.ToList();
        }

        public Candidate GetByID(int Id)
        {
            return _Context.Candidates.Where(x => x.CandidateId == Id).FirstOrDefault();
        }

        public void Remove(int Id)
        {
            Candidate Remove = _Context.Candidates.Find(Id);
            _Context.Candidates.Remove(Remove);
        }

        public void SaveChanges()
        {
            _Context.SaveChanges();
        }

        public void Update(Candidate candidate)
        {
            _Context.Entry(candidate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
