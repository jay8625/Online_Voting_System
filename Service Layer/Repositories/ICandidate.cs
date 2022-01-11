using DAL_Data_Access_Layer_.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service_Layer.Repositories
{
    public interface ICandidate
    {
        IEnumerable<Candidate> GetAll();
        void Add(Candidate candidate);
        void Update(Candidate candidate);
        bool Any(int Id);
        Candidate GetByID(int Id);
        void SaveChanges();
        void Remove(int Id);
    }
}
