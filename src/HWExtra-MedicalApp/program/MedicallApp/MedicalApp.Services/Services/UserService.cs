using MedicalApp.Domain.Entitys;
using MedicalApp.Domain.Exceptions;
using MedicalApp.Persistence.Repositories;
using System.Collections.Generic;

namespace MedicalApp.Services.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUserById(int id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
            {
                throw new ExceptionServices($"No se encontró un usuario con el ID {id}.");
            }
            return user;
        }

        public List<User> GetAllUsers()
        {
            var users = _userRepository.GetAll();
            if (users == null || users.Count == 0)
            {
                throw new ExceptionServices("No hay usuarios registrados.");
            }
            return users;
        }

        public void AddUser(User user)
        {
            if (user == null)
            {
                throw new ExceptionServices("El usuario a agregar no puede ser nulo.");
            }
            _userRepository.Add(user);
        }

        public void UpdateUser(User user)
        {
            if (user == null)
            {
                throw new ExceptionServices("El usuario a actualizar no puede ser nulo.");
            }
            _userRepository.Update(user);
        }

        public void DeleteUser(int id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
            {
                throw new ExceptionServices($"No se puede eliminar. No existe un usuario con el ID {id}.");
            }
            _userRepository.Delete(user);
        }
    }