using System.Linq;
using FTV.DAL;
using FTV.DAL.Models;
using Repositories;

namespace FTV.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            FTVContext context = new FTVContext();
            System.Console.WriteLine(context.Users.ToList().Count());

//            using (var unitofWork = new UnitOfWork(new FTVContext()))
//            {
//                System.Console.WriteLine(unitofWork.Users.GetFirstUser());
//                /*
//
//                var john = new User
//                {
//                    Id = 1,
//                    FirstName = "john",
//                    LastName = "dominguez",
//                    Email = "123@gmail.com",
//                    Password = "123",
//                    UserName = "Sougyo",
//                    InGameName = "Sougyo"
//                };
//                unitofWork.Users.Add(john);
//                unitofWork.Complete();
//
//                System.Console.WriteLine(unitofWork.Users.Get(1).UserName);
//                */
//                System.Console.ReadKey();
//            }
            
           
        }
    }
}
