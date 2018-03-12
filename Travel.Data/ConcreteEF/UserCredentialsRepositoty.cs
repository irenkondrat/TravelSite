using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Travel.Data.Entities;
using Travel.Data.Interface;

namespace Travel.Data.ConcreteEF
{
    public class UserCredentialsRepositoty: IUserCredentialsRepositoty,IDisposable
    {
        private TravelContext _db = new TravelContext();

        public IEnumerable<UserCredentials> GetAll()
        {
            return _db.UserCredentials;
        }
        public UserCredentials GetById(int id)
        {
            return _db.UserCredentials.FirstOrDefault(u => u.Id == id);
        }
        public UserCredentials Add(UserCredentials userCredentials)
        {
            _db.UserCredentials.Add(userCredentials);
            _db.SaveChanges(); 
            return userCredentials;
        }

        public void Delete(int id)
        {
            UserCredentials userCredentials = _db.UserCredentials.FirstOrDefault(u => u.Id == id);
            if (userCredentials != null)
            {
                _db.UserCredentials.Remove(userCredentials);
                _db.SaveChanges();
            }
        }

        public void EditPassword(int id, string newPassword)
        {
            UserCredentials userCredentials = _db.UserCredentials.FirstOrDefault(u => u.Id == id);
            if (userCredentials != null)
            {
                userCredentials.Password = newPassword;
                _db.Entry(userCredentials).State = EntityState.Modified;
                _db.SaveChanges();
            }
        }

        public string GetRole(string email, string password)
        {
            return _db.UserCredentials.FirstOrDefault(u => u.Email==email && u.Password==password)?.Role;
        }

        public bool CheckByEmail(string email)
        {
            if(_db.UserCredentials.FirstOrDefault(u => u.Email == email) != null)
             return true;
            else
                return false;

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
