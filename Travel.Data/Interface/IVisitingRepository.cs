using System.Collections.Generic;
using Kondrat.PracticeTask.Travel.Data.Entities;

namespace Kondrat.PracticeTask.Travel.Data.Interface
{
    public interface IVisitingRepository
    {
        IEnumerable<Visiting> GetAllByIdUser(int id);
        IEnumerable<Visiting> GetAllByIdCity(int id);
        Visiting GetById(int id);
        void Add(Visiting visiting);
        void Edit(Visiting visiting);
        void Delete(int id);


    }
}
