using DAL_Data_Access_Layer_.Model;
using System.Collections.Generic;

namespace Service_Layer.Repositories
{
    public interface IUser
    {
        IEnumerable<User> GetAll();
        void Update(User user);
        void Add(User user);
        bool Any(int Id);
        User GetByID(int Id);
        void Remove(int Id);
        void ChoiceCandidate(int Id);
    }
}
