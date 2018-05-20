using System.Linq;
using FTV.DAL;
using FTV.DAL.Models;
using Repositories;

namespace FTV.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var unitofWork = new UnitOfWork(new FTVContext()))
            {
                System.Console.WriteLine($"User's Size: {unitofWork.Users.GetAll().Count()}");

                
//                unitofWork.Users.Remove(user);
                unitofWork.Users.Add(new User
                {
                    FirstName = "john",
                    LastName = "dominguez",
                    Email = "123@gmail.com",
                    Password = "123456",
                    UserName = "Sougyo",
                    InGameName = "Sougyo"
                });
                unitofWork.Complete();

                System.Console.WriteLine($"User's Size: {unitofWork.Users.GetAll().Count()}");
                var user = unitofWork.Users.Find(x => x.UserName == "Sougyo").First();
                unitofWork.Users.Remove(user);
                unitofWork.Complete();

                System.Console.WriteLine($"User's Size: {unitofWork.Users.GetAll().Count()}");

               
                
            }
        }
    }
}

/*
 Users.Add(new User
   {
   Id = 1,
   FirstName = "john",
   LastName = "dominguez",
   Email = "123@gmail.com",
   Password = "123456",
   UserName = "Sougyo",
   InGameName = "Sougyo"
   }); 
 */
