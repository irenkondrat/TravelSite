﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using Kondrat.PracticeTask.Travel.BL.Exceptions;
using Kondrat.PracticeTask.Travel.BL.Interface;
using Kondrat.PracticeTask.Travel.BL.Security;
using Kondrat.PracticeTask.Travel.Data.Entities;
using Kondrat.PracticeTask.Travel.Data.Interface;

namespace Kondrat.PracticeTask.Travel.BL.Services
{
    public class UserServise:IUserServise
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserCredentialsRepository _userCredentialsRepository;


        public UserServise(IUserRepository userRepository, IUserCredentialsRepository userCredentialsRepository)
        {
            _userRepository = userRepository;
            _userCredentialsRepository = userCredentialsRepository;

        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public bool Add(User user, UserCredentials userCredentials)
        {

            if (userCredentials.Password == null || userCredentials.Email == null)
                throw new IncorrectDataException("Data not correct");
            if (_userCredentialsRepository.CheckByEmail(userCredentials.Email))
                throw new IncorrectDataException("Email booked");
            if (userCredentials.Role == null)
                userCredentials.Role = "User";
            userCredentials.RegistrationDate = DateTime.Now;
            userCredentials.Password = SaltedHashGenerator.GenerateHash(userCredentials.Password, userCredentials.Email);
            try
            {
                _userRepository.Add(user,userCredentials);
                return true;
            }
            catch (DbEntityValidationException ex)
            {             
                throw new IncorrectDataException(DbEntityValidationExceptioErrorMessages.ErrorMessages(ex));
            }
        }

        public bool Edit(User user, int id)
        {
            var oldData = _userRepository.GetById(id);
            if(oldData==null)
                throw new IncorrectDataException("Data not correct");
            oldData.LastName = CompareStringData(oldData.LastName, user.LastName);
            oldData.FirstName = CompareStringData(oldData.FirstName, user.FirstName);
            oldData.NickName = CompareStringData(oldData.NickName, user.NickName);
            oldData.Сountry = CompareStringData(oldData.Сountry, user.Сountry);
            try
            {
                _userRepository.Edit(user);
                return true;
            }
            catch (DbEntityValidationException ex)
            {
                throw new IncorrectDataException(DbEntityValidationExceptioErrorMessages.ErrorMessages(ex));
            }
        }

        public string CompareStringData(string first, string second)
        {
            if (first != second && second != null)
                return second;
            else
            {
                return first;
            }
        }
    }
}
