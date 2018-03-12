using System.Collections.Generic;
using System.Data.Entity.Validation;
using Kondrat.PracticeTask.Travel.BL.Exceptions;
using Kondrat.PracticeTask.Travel.BL.Interface;
using Kondrat.PracticeTask.Travel.BL.Security;
using Kondrat.PracticeTask.Travel.Data.Entities;
using Kondrat.PracticeTask.Travel.Data.Interface;

namespace Kondrat.PracticeTask.Travel.BL.Services
{
    public class UserCredentialsServise : IUserCredentialsServise
    {
        private readonly IUserCredentialsRepository _userCredentialsRepository;

        public UserCredentialsServise(IUserCredentialsRepository userCredentialsRepository)
        {
            _userCredentialsRepository = userCredentialsRepository;
        }

        public UserCredentials GetByEmailAndPassword(string email, string password)
        {
            string hashPassword = SaltedHashGenerator.GenerateHash(password, email);
            return _userCredentialsRepository.GetByEmailAndPassword(email, hashPassword);
        }

        public IEnumerable<UserCredentials> GetAll()
        {
            return _userCredentialsRepository.GetAll();
        }

        public UserCredentials GetById(int id)
        {
            return _userCredentialsRepository.GetById(id);
        }

       
        public bool Delete(int id)
        {
            try
            {
                _userCredentialsRepository.Delete(id);
                return true;
            }
            catch (DbEntityValidationException ex)
            {
                throw new IncorrectDataException(DbEntityValidationExceptioErrorMessages.ErrorMessages(ex));
            }
        }

        public bool EditPassword(int id, string newPassword, string oldPassword)
        {
            try
            {
                UserCredentials userCredentials = _userCredentialsRepository.GetById(id);
                string oldP = SaltedHashGenerator.GenerateHash(oldPassword, userCredentials.Email);
                if (oldP != userCredentials.Password)
                    throw new IncorrectDataException("Passwords do not match");
                _userCredentialsRepository.EditPassword(id,newPassword);
                return true;
            }
            catch (DbEntityValidationException ex)
            {
                throw new IncorrectDataException(DbEntityValidationExceptioErrorMessages.ErrorMessages(ex));
            }
        }

        public bool CheckByEmail(string email)
        {
           return _userCredentialsRepository.CheckByEmail(email);
        }
    }
}