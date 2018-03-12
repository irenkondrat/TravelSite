using System;
using System.Collections.Generic;
using Kondrat.PracticeTask.Travel.Data.Entities;

namespace Kondrat.PracticeTask.Travel.Data.Interface
{
    public interface IUserCredentialsRepository
    {
        UserCredentials GetByEmailAndPassword(string email, string password);
        Boolean CheckByEmail(string email);
        IEnumerable<UserCredentials> GetAll();
        UserCredentials GetById(int id);
        UserCredentials Add(UserCredentials userCredentials);
        void Delete(int id);
        void EditPassword(int id, string newPassword);
    } 
}
