using System.Collections.Generic;
using Kondrat.PracticeTask.Travel.Data.Entities;

namespace Kondrat.PracticeTask.Travel.BL.Interface
{
    public interface IUserCredentialsServise
    {
        UserCredentials GetByEmailAndPassword(string email, string password);
        IEnumerable<UserCredentials> GetAll();
        UserCredentials GetById(int id);
        bool Delete(int id);
        bool EditPassword(int id, string newPassword, string oldPassword);
        bool CheckByEmail(string email);


    }
}
