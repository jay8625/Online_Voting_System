using DAL_Data_Access_Layer_.Data;
using DAL_Data_Access_Layer_.Model;
using System.Collections.Generic;
using System.Linq;

namespace Service_Layer.Repositories
{
    public class VoteRepo : IVote
    {
        private readonly CommonDbContext _Context;

        public VoteRepo(CommonDbContext context)
        {
            _Context = context;
        }

        public void Add(Vote vote)
        {
            _Context.Votes.Add(vote);
        }

        public IEnumerable<Vote> GetAll()
        {
            return _Context.Votes.ToList();
        }

        public void Remove(int Id)
        {
            Vote Remove = _Context.Votes.Where(x => x.User.UserId == Id).FirstOrDefault();
            _Context.Votes.Remove(Remove);
        }

        public void SaveChanges()
        {
            _Context.SaveChanges();
        }

        public void Update(Vote vote)
        {
            _Context.Entry(vote).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
