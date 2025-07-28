using MedicalApp.Domain.Entitys;
using MedicalApp.Domain.Enums;
using MedicalApp.Domain.Exceptions;
using MedicalApp.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp.Visual.Views.Secundary_Views
{
    public class UserViews
    {
        private InputData _input {  get; set; }
        private UserService _userService { get; set; }
        private DoctorService _doctorService { get; set; }  

        public UserViews(InputData input, UserService userService, DoctorService doctorService)
        {
            _input = input;
            _userService = userService;
            _doctorService = doctorService;
        }
       
        public void GetUserByIDView()
        {
            Console.Clear();
            Console.WriteLine("Estos son los usuarios: ");
            List<User> users = _userService.GetAllUsers();
            if(users.Count == 0)
            {
                Console.WriteLine("Lo sentimos pero no tienes usuarios registrados");
                return;
            }

           
            int i = 1;
            foreach (User user in users)
            {
                Console.WriteLine($"{i}){user.Username} | ");
                i++;
            }

            int choice = _input.GetInt("\nIntroduce el numero de usuario del que quieres la informacion: ", i);
            int id = users[choice - 1].Id;
            User userCheck = _userService.GetUserById_WithDoctorData(id);

            Console.Clear();
            Console.WriteLine($"Nombre de usuario: {userCheck.Username}");
            Console.WriteLine($"Contraseña: {userCheck.Password}");
            Console.WriteLine("Los roles que tiene son: ");
            foreach (Rol rol in userCheck.Rols) 
            { 
                Console.Write(rol.ToString()+", ");
            }

            if (userCheck.DoctorId != null)
            {
                var d = userCheck.Doctor.Person;
                Console.WriteLine($"Doctor: {d.Name} {d.Lastname}");
                Console.Write("Especialidades: ");
                foreach (var s in userCheck.Doctor.Specialties)
                {
                    Console.Write($"{s.ToString()}, ");
                }
            }

        }

        public void GetAllUsers()
        {
            Console.Clear();
            Console.WriteLine("Estos son los usuarios: ");
            List<User> users = _userService.GetAllUsers();
            if (users.Count == 0)
            {
                Console.WriteLine("Lo sentimos pero no tienes usuarios registrados");
                return;
            }

            int i = 1;
            foreach (User user in users)
            {
                Console.WriteLine($"{i}){user.Username} | ");
                foreach (Rol rol in user.Rols)
                {
                    Console.Write(rol.ToString() + ", ");
                }
                foreach (Rol rol in user.Rols)
                {
                    Console.Write(rol.ToString() + ", ");
                }
                i++;
            }
        }

        public void AddUserView()
        {
            Console.Clear();
            Doctor doctor = null;
            User user = new User();
            Console.WriteLine("Bienvenido a la creacion de usuarios, necesito que llene los siguientes campos:");
            string usename = _input.GetString("Nombre de usuario: ");
            string password = _input.GetString("Contraseña: ");
            List<Rol> rols = _input.GetRols();
            
            bool confirmDoctor = _input.GetBool("Quieres vincular a un doctor con este usuario?");
            if (confirmDoctor)
            {
                doctor = _connectDoctorWithUser();
            }
            

            user = new User(rols, usename, password, doctor);

            _userService.AddUser(user);

        }

        private Doctor _connectDoctorWithUser()
        {
            List<Doctor> doctors;
            Doctor doctor = new Doctor();
            try
            {
                doctors = _doctorService.GetAllDoctor_WithPersonData_NoHaveUser();
                int i = 1;

                Console.WriteLine("Estos son los doctores sin usuario:");
                foreach (Doctor d in doctors)
                {
                    Person p = d.Person;
                    Console.WriteLine($"{i}){p.Name} {p.Lastname}");
                    i++;
                }
                int choice = _input.GetInt("\nIntroduce el numero del doctor a vincular: ", i);
                int id = doctors[choice - 1].Id;
                doctor = _doctorService.GetDoctorById(id);
                return doctor;
            }
            catch (ExceptionServices ex)
            {
                _input.ColorError();
                Console.WriteLine(ex.Message);
                _input.ColorNormal();
                return null;
            }
        }

        public void UpdateUserView()
        {
            List<User> users;
            try
            {
                users = _userService.GetAllUsers();
            }
            catch (ExceptionServices ex)
            {
                _input.ColorError();    
                Console.WriteLine(ex.Message);
                _input.ColorNormal();
                return;
            }


            while(true)
            {
                Console.WriteLine("Estos son los usuarios que puedes modificar: ");
                int i = 1;
                foreach (User user in users)
                {
                    Console.WriteLine($"{i}){user.Username} | ");
                    foreach (Rol rol in user.Rols)
                    {
                        Console.Write(rol.ToString() + ", ");
                    }
                    i++;
                }
            }


        }
    }
}
