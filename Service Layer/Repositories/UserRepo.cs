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
            IEnumerable<vwUser> vwUsers = new List<vwUser>();
            vwUsers = _Context.Users.Select(u => new vwUser()
            {
                UserId=u.UserId,
                FirstName = u.FirstName,
                LastName = u.LastName
            }).ToList();
            return vwUsers;
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

        public void ChoiceCandidate(int Id)
        {
            var Choice = _Context.Users.Select(s => s.ChoiceCandidateId);
            _Context.SaveChanges();
        }
    }
}



