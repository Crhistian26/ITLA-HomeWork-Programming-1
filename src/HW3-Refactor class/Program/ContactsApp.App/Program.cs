using ContactsApp.App.Entitys;
using Microsoft.Win32.SafeHandles;
using System.Diagnostics;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;

namespace ContactsApp.App
{
    internal class Program
    {
        static List<Contact> contacts = new List<Contact>()
        {
            new Contact(1,"Alberto","Gutierrez","8096785678","Los Alcarrizos","Alberto@gmail.com",21,true),
            new Contact(2,"Henrique","Carrasco","8490987685" ,"Federico Guzman","Carrasco@gmail.com",23,false)
        };
    
        static void Main(string[] args)
        {
        }
    }
}
