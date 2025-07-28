using MedicalApp.Domain.Entitys;
using MedicalApp.Domain.Exceptions;
using MedicalApp.Persistence;
using MedicalApp.Persistence.Repositories;
using MedicalApp.Services.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp.Visual.Views.Principal_Views
{
    public class GeneralViews : PrincipalViewBase
    {

        static private UserRepository _userRepository;
        static private UserService _userService;
        static InputData _input = new InputData();

        public GeneralViews(MedicalContext medicalContext) : base(medicalContext) 
        {
            _userRepository = new UserRepository(_medicalContext);
            _userService = new UserService(_userRepository);
        }
        public User Login()
        {
            User user = new User();
            int trys = 3;
            do
            {
                string username = _input.GetString("Ingrese su nombre de usuario: ");
                string password = _input.GetString("Ingrese su contraseña: ");
                try
                {
                    user = _userService.Login(username, password);
                }
                catch (ExceptionServices ex)
                {
                    _input.ColorError();
                    Console.WriteLine("\n" + ex.Message);

                }
                finally { _input.ColorNormal(); }

                if (user != null)
                {
                    break;
                }

                trys--;

            } while (trys > 0);

            if (trys == 0)
            {
                Console.WriteLine("Te bloqueamos la entrada al sistema por no tener un usuario");
                Console.ReadLine();
                Environment.Exit(0);
            }

            return user;
        }
    }
}
