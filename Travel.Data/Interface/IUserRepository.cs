using System.Collections.Generic;
using Kondrat.PracticeTask.Travel.Data.Entities;

namespace Kondrat.PracticeTask.Travel.Data.Interface
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        void Add(User user, UserCredentials userCredentials);
        void Edit(User user);
    }
}
