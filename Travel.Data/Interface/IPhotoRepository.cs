using System.Collections.Generic;
using Kondrat.PracticeTask.Travel.Data.Entities;

namespace Kondrat.PracticeTask.Travel.Data.Interface
{
    public interface IPhotoRepository
    {
        IEnumerable<Photo> GetByIdComment(int id);
        Photo GetByUserId(int id);
        void Add(Photo city);
    }
}
