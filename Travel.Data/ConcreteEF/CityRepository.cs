using System;
using System.Collections.Generic;
using System.Linq;
using Kondrat.PracticeTask.Travel.Data.Entities;
using Kondrat.PracticeTask.Travel.Data.Interface;

namespace Kondrat.PracticeTask.Travel.Data.ConcreteEF
{
    public class CityRepository:ICityRepository, IDisposable
    {
        private TravelContext _db = new TravelContext();

        public IEnumerable<City> GetAll()
        {
            return _db.Cities;
        }

        public City GetById(int id)
        {
            return _db.Cities.FirstOrDefault(c => c.Id == id);
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
