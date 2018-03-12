using System.Collections.Generic;
using Travel.Data.Entities;

namespace Travel.BL.Interface
{
    public interface IUserServise
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        bool Add(User user, UserCredentials userCredentials);
        bool Edit(User user, int id);
    }
}
