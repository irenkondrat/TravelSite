using System.Collections.Generic;
using Travel.Data.Entities;

namespace Travel.BL.Interface
{
    public interface IUserCredentialsServise
    {
        string GetRole(string email, string password);
        IEnumerable<UserCredentials> GetAll();
        UserCredentials GetById(int id);
        bool Delete(int id);
        bool EditPassword(int id, string newPassword, string oldPassword);
        bool CheckByEmail(string email);


    }
}
