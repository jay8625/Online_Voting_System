using DAL_Data_Access_Layer_.Data;
using DAL_Data_Access_Layer_.Model;
using Service_Layer.vwModel;
using System.Collections.Generic;
using System.Linq;

namespace Service_Layer.Repositories
{
    public class UserRepo : IUser
    {
        private readonly CommonDbContext _Context;

        public UserRepo(CommonDbContext Context)
        {
            _Context = Context;
        }
        public IEnumerable<vwUser> vwUsers()
        {
            return _Context.Users.Select(u => new vwUser()
            {
                UserId = u.UserId,
                FirstName = u.FirstName,
                LastName = u.LastName,
                VoteStatus = u.ChoiceCandidateId,
                CandidateName=_Context.Candidates.Where(x=>x.CandidateId==u.ChoiceCandidateId).Select(s=>s.FirstName+" "+s.LastName).FirstOrDefault(),
            });
        }

        public bool Any(int Id)
        {
            if (_Context.Users.Any(e => e.UserId == Id))
            {
                return true;
            }
            return false;
        }

        public IEnumerable<User> GetAll()
        {
            return _Context.Users.ToList();
        }

        public User GetByID(int Id)
        {
            return _Context.Users.FirstOrDefault(x => x.UserId == Id);
        }

        public void Remove(int Id)
        {
            User Remove = _Context.Users.Find(Id);
            _Context.Users.Remove(Remove);
            _Context.SaveChanges();
        }

        public void Update(User user)
        {
            _Context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _Context.SaveChanges();
        }

        public void Add(User user)
        {
            _Context.Users.Add(user);
            _Context.SaveChanges();
        }

        public List<vwUser> SortFirstName()
        {
            List<vwUser> Sorted=_Context.Users.Select(s=>new vwUser
            {
                FirstName = s.FirstName,
                LastName = s.LastName,
                UserId = s.UserId,
                VoteStatus=s.ChoiceCandidateId
            }).OrderBy(x => x.FirstName).ToList();
            return Sorted;
        }

        public List<vwUser> SortLastName()
        {
            List<vwUser> Sorted = _Context.Users.Select(s => new vwUser
            {
                FirstName = s.FirstName,
                LastName = s.LastName,
                UserId = s.UserId,
                VoteStatus = s.ChoiceCandidateId
            }).OrderBy(x => x.LastName).ToList();
            return Sorted;
        }

        public List<vwUser> SortVote()
        {
            List<vwUser> Sorted = _Context.Users.Select(s => new vwUser
            {
                FirstName = s.FirstName,
                LastName = s.LastName,
                UserId = s.UserId,
                VoteStatus = s.ChoiceCandidateId
            }).OrderBy(x => x.VoteStatus).ToList();
            return Sorted;
        }

        public void SortLastName(User user)
        {
            _Context.Users.OrderByDescending(x => x.LastName);
        }
    }
}

            


