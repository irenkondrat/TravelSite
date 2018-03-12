using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Kondrat.PracticeTask.Travel.Data.Entities;
using Kondrat.PracticeTask.Travel.Data.Interface;

namespace Kondrat.PracticeTask.Travel.Data.ConcreteEF
{
    public class VisitingRepository:IVisitingRepository,IDisposable
    {
        private TravelContext _db = new TravelContext();

        public IEnumerable<Visiting> GetAllByIdUser(int id)
        {
            return _db.Visiting.Where(c => c.UserId == id);
        }

        public IEnumerable<Visiting> GetAllByIdCity(int id)
        {
            return _db.Visiting.Where(c => c.CityId == id);
        }

        public Visiting GetById(int id)
        {
            return _db.Visiting.FirstOrDefault(c => c.Id == id);
        }

        public void Add(Visiting visiting)
        {
            _db.Visiting.Add(visiting);
            _db.SaveChanges();
        }

        public void Edit(Visiting visiting)
        {
            if (visiting != null)
            {
                using (var transaction = _db.Database.BeginTransaction())
                {
                    try
                    {
                        _db.Entry(visiting).State = EntityState.Modified;
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

        public void Delete(int id)
        {
            var visiting = _db.Visiting.FirstOrDefault(u => u.Id == id);
            if (visiting == null) return;
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    _db.SaveChanges();
                    _db.Visiting.Remove(visiting);
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
