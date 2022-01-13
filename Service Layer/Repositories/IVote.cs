using DAL_Data_Access_Layer_.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service_Layer.Repositories
{
    public interface IVote
    {
        IEnumerable<Vote> GetAll();
        void Add(Vote vote);
        void Update(Vote vote);
        //bool Any(int Id);
        //Vote GetByID(int Id);
        void SaveChanges();
        void Remove(int Id);
    }
}
