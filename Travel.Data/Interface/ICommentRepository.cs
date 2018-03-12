using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kondrat.PracticeTask.Travel.Data.Entities;

namespace Kondrat.PracticeTask.Travel.Data.Interface
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> GetAllByIdCity(int id);
        Comment GetById(int id);
        void Add(Comment comment);
        void Edit(Comment comment);
        void Delete(int id);


    }
}
