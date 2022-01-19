using DAL_Data_Access_Layer_.Model;
using Service_Layer.vwModel;
using System.Collections.Generic;

namespace Service_Layer.Repositories
{
    public interface IUser
    {
        //gets all Users
        IEnumerable<User> GetAll();
        //get users as per vwModel
        IEnumerable<vwUser> vwUsers();
        //Updates User info
        void Update(User user);
        //adds new user
        void Add(User user);
        //condition by Id
        bool Any(int Id);
        //gets user by Id
        User GetByID(int Id);
        //removes User by Id
        void Remove(int Id);
        //sorts User by firstname
        List<vwUser> SortFirstName();
        //sorts User by Lastname
        List<vwUser> SortLastName();
        //sorts User by vote
        List<vwUser> SortVote();
    }
}
