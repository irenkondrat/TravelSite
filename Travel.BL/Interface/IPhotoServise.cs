using System.Collections.Generic;
using Travel.Data.Entities;

namespace Travel.BL.Interface
{
    public interface IPhotoServise
    {
        IEnumerable<Photo> GetByIdComment(int id);
        Photo GetByUserId(int id);
        void AddToUser(string address, int id);
        void AddToComment(string address, int id);

    }
}
