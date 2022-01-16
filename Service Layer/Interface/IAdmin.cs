using DAL_Data_Access_Layer_.Model;
using System.Collections.Generic;

namespace Service_Layer.Repositories
{
    public interface IAdmin
    {
        IEnumerable<Admin> GetAll();
        void Add(Admin admin);
        void Update(Admin admin);
        bool Any(int Id);
        Admin GetByID(int Id);
        void Remove(int Id);
    }
}
