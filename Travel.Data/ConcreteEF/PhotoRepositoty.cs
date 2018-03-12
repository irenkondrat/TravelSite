using System;
using System.Collections.Generic;
using System.Linq;
using Travel.Data.Entities;
using Travel.Data.Interface;

namespace Travel.Data.ConcreteEF
{
    class PhotoRepositoty:IPhotoRepositoty, IDisposable
    {
        private TravelContext _db = new TravelContext();
       
        public IEnumerable<Photo> GetByIdComment(int id)
        {
            return _db.Photos.Where(u => u.CommentId == id);
        }

        public Photo GetByUserId(int id)
        {
            return _db.Photos.FirstOrDefault(u => u.UserId == id);
        }

        public void Add(Photo photo)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    _db.Photos.Add(photo);
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
