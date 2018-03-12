using System.Collections.Generic;
using Travel.Data.Entities;

namespace Travel.Data.Interface
{
    public interface IUserRepositoty
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        void Add(User user, UserCredentials userCredentials);
        void Edit(User user);
    }
}
