using System;
using System.Collections.Generic;
using Travel.Data.Entities;

namespace Travel.Data.Interface
{
    public interface IUserCredentialsRepositoty
    {
        string GetRole(string email, string password);
        Boolean CheckByEmail(string email);
        IEnumerable<UserCredentials> GetAll();
        UserCredentials GetById(int id);
        UserCredentials Add(UserCredentials userCredentials);
        void Delete(int id);
        void EditPassword(int id, string newPassword);
    } 
}
