using MedicalApp.Domain;
using MedicalApp.Domain.Entitys;
using MedicalApp.Domain.Enums;
using MedicalApp.Domain.Exceptions;
using MedicalApp.Persistence;
using MedicalApp.Persistence.Migrations;
using MedicalApp.Persistence.Repositories;
using MedicalApp.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Xml.Schema;

namespace MedicalApp.Visual
{
    internal class Program
    {
        static User user;
        static void Main(string[] args)
        {
            
            InputData inputs = new InputData();
            MedicalContext context = new MedicalContext(new DbContextOptionsBuilder<MedicalContext>().Options,new User());
            UserRepository userRepository = new UserRepository(context);
            UserService _userService = new UserService(userRepository);



            int trys = 3;
            do
            {   
                string username = inputs.GetString("Ingrese su nombre de usuario: ");
                string password = inputs.GetString("Ingrese su contraseña: ");
                try
                {
                    user = _userService.Login(username, password);
                }
                catch(ExceptionServices ex)
                {
                    inputs.ColorError();
                    Console.WriteLine("\n"+ex.Message);
                    
                }
                finally { inputs.ColorNormal(); }
                
                if(user != null)
                {
                    break;
                }

                trys--;

            }while(trys > 0);

            if (trys == 0)
            {
                Console.WriteLine("Te bloqueamos la entrada al sistema por no tener un usuario");
                Console.ReadLine();
                Environment.Exit(0);
            }


        }
    }
}
