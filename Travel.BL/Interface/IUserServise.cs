using System.Collections.Generic;
using Kondrat.PracticeTask.Travel.Data.Entities;

namespace Kondrat.PracticeTask.Travel.BL.Interface
{
    public interface IUserServise
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        bool Add(User user, UserCredentials userCredentials);
        bool Edit(User user, int id);
    }
}
