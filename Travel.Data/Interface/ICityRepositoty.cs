using System.Collections.Generic;
using Travel.Data.Entities;

namespace Travel.Data.Interface
{
    public interface ICityRepositoty
    {
        IEnumerable<City> GetAll();
        City GetById(int id);
        void Add(City city);
    }
}
