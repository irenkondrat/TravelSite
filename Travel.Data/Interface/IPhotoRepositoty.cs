using System.Collections.Generic;
using Travel.Data.Entities;

namespace Travel.Data.Interface
{
    public interface IPhotoRepositoty
    {
        IEnumerable<Photo> GetByIdComment(int id);
        Photo GetByUserId(int id);
        void Add(Photo city);
    }
}
