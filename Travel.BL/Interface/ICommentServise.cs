using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kondrat.PracticeTask.Travel.Data.Entities;

namespace Kondrat.PracticeTask.Travel.BL.Interface
{
    public interface ICommentServise
    {
        IEnumerable<Comment> GetAllByIdCity(int id);
        Comment GetById(int id);
        void Add(Comment comment);
        void Edit(int idComment, int IdAdmin, string newTextComment);
        void Delete(int idComment, int idUser);
    }
}
