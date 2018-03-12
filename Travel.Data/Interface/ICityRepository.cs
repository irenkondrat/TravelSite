using System.Collections.Generic;
using Kondrat.PracticeTask.Travel.Data.Entities;

namespace Kondrat.PracticeTask.Travel.Data.Interface
{
    public interface ICityRepository
    {
        IEnumerable<City> GetAll();
        City GetById(int id);
        void Add(City city);
    }
}
