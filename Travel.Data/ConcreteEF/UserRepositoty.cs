using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Travel.Data.Entities;
using Travel.Data.Interface;

namespace Travel.Data.ConcreteEF
{
    public class UserRepositoty:IUserRepositoty, IDisposable
    {
        private TravelContext _db = new TravelContext();

        public IEnumerable<User> GetAll()
        {
            return _db.Users;
        }
        public User GetById(int id)
        {
            return _db.Users.FirstOrDefault(u => u.Id == id);
        }

        public void Add(User user, UserCredentials userCredentials)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    _db.Users.Add(user);
                    _db.SaveChanges();
                    userCredentials.Id = user.Id;
                    _db.UserCredentials.Add(userCredentials);
                    _db.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void Edit(User user)
        {
            if (user != null)
            {
                using (var transaction = _db.Database.BeginTransaction())
                {
                    try
                    {
                        _db.Entry(user).State = EntityState.Modified;
                        _db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_db != null)
                {
                    _db.Dispose();
                    _db = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
