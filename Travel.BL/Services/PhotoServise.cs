using System.Collections.Generic;
using System.Data.Entity.Validation;
using Travel.BL.Exceptions;
using Travel.BL.Interface;
using Travel.Data.Entities;
using Travel.Data.Interface;

namespace Travel.BL.Services
{
   public class PhotoServise : IPhotoServise
    {
         private readonly IPhotoRepositoty _photoRepository;

        private readonly string _file;


        public PhotoServise(IPhotoRepositoty userCredentialsRepository)
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
