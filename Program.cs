using System;
using System.Linq;

namespace ISP_Lab15
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var db = new PhoneBookDb())
            {
                CreateUsers(db);

                Console.WriteLine("База данных после вставки:");
                PrintUsers(db);

                UpdateFirstUser(db);

                Console.WriteLine("База данных после обновления первого пользователя:");
                PrintUsers(db);

                DeleteFirstUser(db);

                Console.WriteLine("База данных после удаления первого пользователя:");
                PrintUsers(db);

                Console.WriteLine("Оставшиеся номера телефонов");
                foreach (PhoneNumber phone in db.Phones)
                {
                    Console.WriteLine(phone);
                }

                db.Database.EnsureDeleted();
            }
            Console.ReadLine();
        }

        public static void DeleteFirstUser(PhoneBookDb db)
        {
            User user = db.Users.First();
            db.Users.Remove(user);
            db.SaveChanges();
        }

        public static void UpdateFirstUser(PhoneBookDb db)
        {
            User user = db.Users.First();
            user.Phones.RemoveAt(0);
            db.Users.Update(user);
            db.SaveChanges();
        }

        public static void CreateUsers(PhoneBookDb db)
        {
            User user1 = new User()
            {
                FirstName = "Ivan",
                LastName = "Jurnaliev",
                Birthday = DateTime.Parse("12.05.1990")
            };
            User user2 = new User()
            {
                FirstName = "Peter",
                LastName = "Ivanov",
                Birthday = DateTime.Parse("21.10.1999")
            };
            User user3 = new User()
            {
                FirstName = "Euhen",
                LastName = "Petrov",
                Birthday = DateTime.Parse("11.11.2011")
            };

            PhoneNumber phone1 = new PhoneNumber()
            {
                Number = "+375259110001"
            };
            PhoneNumber phone2 = new PhoneNumber()
            {
                Number = "+375291005001"
            };
            PhoneNumber phone3 = new PhoneNumber()
            {
                Number = "+375332505002"
            };

            user1.Phones.Add(phone1);
            user1.Phones.Add(phone2);
            user2.Phones.Add(phone3);

            db.Users.AddRange(user1, user2, user3);
            db.SaveChanges();
        }

        private static void PrintUsers(PhoneBookDb db)
        {
            foreach (User user in db.Users)
            {
                Console.WriteLine(user);
                Console.WriteLine(user.Phones.Count() > 0 ? "Телефоны пользователя" : 
                    "У пользователя нет телефонов");
                foreach (PhoneNumber phone in user.Phones)
                {
                    Console.WriteLine(phone);
                }
                Console.WriteLine();
            }
        }
    }
}
