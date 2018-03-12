using System.Collections.Generic;
using Kondrat.PracticeTask.Travel.Data.Entities;

namespace Kondrat.PracticeTask.Travel.BL.Interface
{
    public interface IPhotoServise
    {
        IEnumerable<Photo> GetByIdComment(int id);
        Photo GetByUserId(int id);
        void AddToUser(string address, int id);
        void AddToComment(string address, int id);

    }
}
