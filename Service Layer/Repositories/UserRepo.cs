using DAL_Data_Access_Layer_.Data;
using DAL_Data_Access_Layer_.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service_Layer.Repositories
{
    public class UserRepo : IUser
    {
        private readonly CommonDbContext _Context;

        public UserRepo(CommonDbContext Context)
        {
            _Context = Context;
        }

        public void Add(User user)
        {
            _Context.Users.Add(user);
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
        }

        public void SaveChanges()
        {
            _Context.SaveChanges();
        }

        public void Update(User user)
        {
            _Context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
