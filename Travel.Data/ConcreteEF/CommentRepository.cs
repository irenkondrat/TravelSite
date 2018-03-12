using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Kondrat.PracticeTask.Travel.Data.Entities;
using Kondrat.PracticeTask.Travel.Data.Interface;

namespace Kondrat.PracticeTask.Travel.Data.ConcreteEF
{
    public class CommentRepository:ICommentRepository,IDisposable
    {
        private TravelContext _db = new TravelContext();

        public IEnumerable<Comment> GetAllByIdCity(int id)
        {
            return _db.Comments.Where(c => c.CityId == id);
        }

        public Comment GetById(int id)
        {
            return _db.Comments.FirstOrDefault(c => c.Id == id);
        }

        public void Add(Comment comemnt)
        {
            _db.Comments.Add(comemnt);
            _db.SaveChanges();
        }

        public void Edit(Comment comment)
        {
            if (comment != null)
            {
                using (var transaction = _db.Database.BeginTransaction())
                {
                    try
                    {
                        _db.Entry(comment).State = EntityState.Modified;
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
            var comment = _db.Comments.FirstOrDefault(u => u.Id == id);
            if (comment == null) return;
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    var photos = _db.Photos.Where(p => p.CommentId == id);
                    foreach (var p in photos)
                    {
                        _db.Photos.Remove(p);
                    }
                    _db.SaveChanges();
                    _db.Comments.Remove(comment);
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
