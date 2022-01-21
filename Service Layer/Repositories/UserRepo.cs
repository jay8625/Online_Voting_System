using DAL_Data_Access_Layer_.Data;
using DAL_Data_Access_Layer_.Model;
using Service_Layer.vwModel;
using System.Collections.Generic;
using System.Linq;

namespace Service_Layer.Repositories
{
    public class UserRepo : IUser
    {
        private readonly CommonDbContext _context;

        public UserRepo(CommonDbContext Context)
        {
            _context = Context;
        }

        //get users as per vwModel
        public IEnumerable<vwUser> vwUsers()
        {
            return _context.Users.Select(u => new vwUser()
            {
                UserId = u.UserId,
                FirstName = u.FirstName,
                LastName = u.LastName,
                VoteStatus = u.ChoiceCandidateId,
                CandidateName=_context.Candidates.Where(x=>x.CandidateId==u.ChoiceCandidateId).Select(s=>s.FirstName+" "+s.LastName).FirstOrDefault(),
                dateTime=u.GetDateTime
            });
        }

        //condition by Id
        public bool Any(int Id)
        {
            if (_context.Users.Any(e => e.UserId == Id))
            {
                return true;
            }
            return false;
        }

        //gets all Users
        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        //gets user by Id
        public User GetByID(int Id)
        {
            return _context.Users.FirstOrDefault(x => x.UserId == Id);
        }

        //removes User by Id
        public void Remove(int Id)
        {
            User Remove = _context.Users.Find(Id);
            _context.Users.Remove(Remove);
            _context.SaveChanges();
        }

        //Updates User info
        public void Update(User user)
        {
            _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        //adds new user
        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        //sorts User by firstname
        public List<vwUser> SortFirstName()
        {
            List<vwUser> Sorted=_context.Users.Select(s=>new vwUser
            {
                FirstName = s.FirstName,
                LastName = s.LastName,
                UserId = s.UserId,
                VoteStatus=s.ChoiceCandidateId
            }).OrderBy(x => x.FirstName).ToList();
            return Sorted;
        }

        //sorts User by Lastname
        public List<vwUser> SortLastName()
        {
            List<vwUser> Sorted = _context.Users.Select(s => new vwUser
            {
                FirstName = s.FirstName,
                LastName = s.LastName,
                UserId = s.UserId,
                VoteStatus = s.ChoiceCandidateId
            }).OrderBy(x => x.LastName).ToList();
            return Sorted;
        }

        //sorts User by vote
        public List<vwUser> SortVote()
        {
            List<vwUser> Sorted = _context.Users.Select(s => new vwUser
            {
                FirstName = s.FirstName,
                LastName = s.LastName,
                UserId = s.UserId,
                VoteStatus = s.ChoiceCandidateId
            }).OrderBy(x => x.VoteStatus).ToList();
            return Sorted;
        }

        //cascade delete when candidate id is to be deleted
        public void CascadeRemove(int Id)
        {
            _context.Users.RemoveRange(_context.Users.Where(x => x.ChoiceCandidateId == Id)); 
        }
    }
}

            


