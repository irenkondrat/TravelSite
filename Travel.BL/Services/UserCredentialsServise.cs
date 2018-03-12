using System.Collections.Generic;
using System.Data.Entity.Validation;
using Travel.BL.Exceptions;
using Travel.BL.Interface;
using Travel.BL.Security;
using Travel.Data.Entities;
using Travel.Data.Interface;

namespace Travel.BL.Services
{
    public class UserCredentialsServise : IUserCredentialsServise
    {
        private readonly IUserCredentialsRepositoty _userCredentialsRepository;

        public UserCredentialsServise(IUserCredentialsRepositoty userCredentialsRepository)
        {
            _userCredentialsRepository = userCredentialsRepository;
        }

        public string GetRole(string email, string password)
        {
            string hashPassword = SaltedHashGenerator.GenerateHash(password, email);
            return _userCredentialsRepository.GetRole(email, hashPassword);
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