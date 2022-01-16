using DAL_Data_Access_Layer_.Model;
using Service_Layer.vwModel;
using System.Collections.Generic;

namespace Service_Layer.Repositories
{
    public interface IUser
    {
        IEnumerable<User> GetAll();
        IEnumerable<vwUser> vwUsers();
        void Update(User user);
        void Add(User user);
        bool Any(int Id);
        User GetByID(int Id);
        void Remove(int Id);
    }
}
