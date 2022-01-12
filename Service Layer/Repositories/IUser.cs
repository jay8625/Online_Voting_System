﻿using DAL_Data_Access_Layer_.Model;
using DAL_Data_Access_Layer_.vwModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service_Layer.Repositories
{
    public interface IUser
    {
        IEnumerable<User> GetAll();
        //IEnumerable<vwUser> GetUsers();
        void Add(User user);
        void Update(User user);
        bool Any(int Id);
        User GetByID(int Id);
        void SaveChanges();
        void Remove(int Id);
    }
}