using DAL_Data_Access_Layer_.Data;
using DAL_Data_Access_Layer_.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service_Layer.Repositories
{
    public class AdminRepo : IAdmin
    {
        private readonly CommonDbContext _Context;

        public AdminRepo(CommonDbContext context)
        {
            _Context = context;
        }

        public void Add(Admin admin)
        {
            _Context.Admins.Add(admin);
            _Context.SaveChanges();
        }

        public bool Any(int Id)
        {
            if (_Context.Admins.Any(e => e.Id == Id))
            {
                return true;
            }
            return false;
        }

        public IEnumerable<Admin> GetAll()
        {
            return _Context.Admins.ToList();
        }

        public Admin GetByID(int Id)
        {
            return _Context.Admins.Where(x=>x.Id==Id).FirstOrDefault();
        }

        public void Remove(int Id)
        {
            Admin Remove = _Context.Admins.Find(Id);
            _Context.Admins.Remove(Remove);
            _Context.SaveChanges();
        }

        public void Update(Admin admin)
        {
            _Context.Entry(admin).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _Context.SaveChanges();
        }
    }
}
