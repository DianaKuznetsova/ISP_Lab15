using System;
using Xunit;
using ISP_Lab15;
using System.Linq;

namespace Lab15_Tests
{
    public class PhoneBookDbTest
    {
        [Fact]
        public void CheckUserAdded()
        {
            using (var db = new PhoneBookDb())
            {
                Program.CreateUsers(db);

                Assert.Equal(3, db.Users.Count());

                Assert.True(db.Users.Any(user => user.LastName.Equals("Jurnaliev")));
                Assert.True(db.Users.Any(user => user.LastName.Equals("Ivanov")));
                Assert.True(db.Users.Any(user => user.LastName.Equals("Petrov")));
                
                Assert.Equal(3, db.Phones.Count());

                Assert.True(db.Phones.Any(phone => phone.Number.Equals("+375259110001")));
                Assert.True(db.Phones.Any(phone => phone.Number.Equals("+375291005001")));
                Assert.True(db.Phones.Any(phone => phone.Number.Equals("+375332505002")));

                db.Database.EnsureDeleted();
            }
        }

        [Fact]
        public void CheckUserDeleted()
        {
            using (var db = new PhoneBookDb())
            {
                PhoneNumber number = new PhoneNumber()
                {
                    Number = "+375336002913"
                };
                User user = new User()
                {
                    FirstName = "Ivan",
                    LastName = "Petrov",
                    Birthday = DateTime.Parse("03.10.1995")
                };
                user.Phones.Add(number);

                db.Users.Add(user);
                db.SaveChanges();

                Assert.Equal(1, db.Users.Count());
                Assert.Equal(1, db.Phones.Count());

                Program.DeleteFirstUser(db);

                Assert.Equal(0, db.Users.Count());
                Assert.Equal(0, db.Phones.Count());

                db.Database.EnsureDeleted();
            }
        }

        [Fact]
        public void CheckUserUpdated()
        {
            using (var db = new PhoneBookDb())
            {
                PhoneNumber number = new PhoneNumber()
                {
                    Number = "+375336002913"
                };
                User user = new User()
                {
                    FirstName = "Ivan",
                    LastName = "Petrov",
                    Birthday = DateTime.Parse("03.10.1995")
                };
                user.Phones.Add(number);

                db.Users.Add(user);
                db.SaveChanges();

                Assert.Equal(1, db.Users.Count());
                Assert.Equal(1, db.Phones.Count());

                Program.UpdateFirstUser(db);

                Assert.Equal(0, db.Phones.Count());
                Assert.Equal(1, db.Users.Count());

                db.Database.EnsureDeleted();
            }
        }
    }
}
