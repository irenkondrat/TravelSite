using System.Collections.Generic;
using System.Data.Entity.Validation;
using Kondrat.PracticeTask.Travel.BL.Exceptions;
using Kondrat.PracticeTask.Travel.BL.Interface;
using Kondrat.PracticeTask.Travel.Data.Entities;
using Kondrat.PracticeTask.Travel.Data.Interface;

namespace Kondrat.PracticeTask.Travel.BL.Services
{
   public class PhotoServise : IPhotoServise
    {
         private readonly IPhotoRepository _photoRepository;

        private readonly string _file;


        public PhotoServise(IPhotoRepository userCredentialsRepository)
        {
            _photoRepository = userCredentialsRepository;
            _file = "~/Images/";
        }

        public IEnumerable<Photo> GetByIdComment(int id)
        {
            return _photoRepository.GetByIdComment(id);
        }

        public Photo GetByUserId(int id)
        {
            return _photoRepository.GetByUserId(id);
        }

        public void AddToUser(string address, int id)
        {
            Photo photo = new Photo { Address = $"{_file}{address}", UserId = id};
                try
                {
                    _photoRepository.Add(photo);
                }
                catch (DbEntityValidationException ex)
                {
                    throw new IncorrectDataException(DbEntityValidationExceptioErrorMessages.ErrorMessages(ex));
                }
        }

        public void AddToComment(string address, int id)
        {
            Photo photo = new Photo { Address = $"{_file}{address}", CommentId =id};
            try
            {
                _photoRepository.Add(photo);
            }
            catch (DbEntityValidationException ex)
            {
                throw new IncorrectDataException(DbEntityValidationExceptioErrorMessages.ErrorMessages(ex));
            }
        }
    }
}
