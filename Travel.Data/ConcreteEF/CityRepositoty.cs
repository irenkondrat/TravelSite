using System;
using System.Collections.Generic;
using Travel.Data.Entities;
using Travel.Data.Interface;

namespace Travel.Data.ConcreteEF
{
    public class CityRepositoty:ICityRepositoty, IDisposable
    {
        private TravelContext _db = new TravelContext();

        public IEnumerable<City> GetAll()
        {
            throw new NotImplementedException();
        }

        public City GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(City city)
        {
            _db.Cities.Add(city);
            _db.SaveChanges();
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
