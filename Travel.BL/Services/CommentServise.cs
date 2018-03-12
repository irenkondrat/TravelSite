using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using Kondrat.PracticeTask.Travel.BL.Exceptions;
using Kondrat.PracticeTask.Travel.BL.Interface;
using Kondrat.PracticeTask.Travel.Data.Entities;
using Kondrat.PracticeTask.Travel.Data.Interface;

namespace Kondrat.PracticeTask.Travel.BL.Services
{
   public class CommentServise:ICommentServise
   {
       private readonly ICommentRepository _commentRepository;
       private readonly IUserCredentialsRepository _userCredentialsRepository;


        public CommentServise(ICommentRepository commentRepository, IUserCredentialsRepository userCredentialsRepository)
        {
            _commentRepository = commentRepository;
            _userCredentialsRepository = userCredentialsRepository;
        }
        public IEnumerable<Comment> GetAllByIdCity(int id)
        {
            return _commentRepository.GetAllByIdCity(id);
        }

        public Comment GetById(int id)
        {
            return _commentRepository.GetById(id);
        }

        public void Add(Comment comment)
        {
            try
            {
                _commentRepository.Add(comment);
            }
            catch (DbEntityValidationException ex)
            {
                throw new IncorrectDataException(DbEntityValidationExceptioErrorMessages.ErrorMessages(ex));
            }
        }

        public void Edit(int idComment, int idAdmin, string newTextComment)
        {
            if(_userCredentialsRepository.GetById(idAdmin).Role!="Admin")
                throw new IncorrectDataException("has no access to edit");
            try
            {
                Comment comment = GetById(idComment);
                comment.Text = newTextComment;
                comment.AdminId = idAdmin;
                comment.LastModifiedDate= DateTime.Now;
                _commentRepository.Edit(comment);
            }
            catch (DbEntityValidationException ex)
            {
                throw new IncorrectDataException(DbEntityValidationExceptioErrorMessages.ErrorMessages(ex));
            }
        }

        public void Delete(int idComment, int idUser)
        {
            var user = _userCredentialsRepository.GetById(idUser);
            var comment = GetById(idComment);

            if (user.Role != "Admin"||user.Id!=comment.UserId)
                throw new IncorrectDataException("has no access to edit");
            try
            {
                _commentRepository.Delete(idComment);
            }
            catch (DbEntityValidationException ex)
            {
                throw new IncorrectDataException(DbEntityValidationExceptioErrorMessages.ErrorMessages(ex));
            }
        }
    }
}
