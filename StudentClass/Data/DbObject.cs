using StudentClass.Data.Models;

namespace StudentClass.Data
{
    public class DbObjects
    {
        public static void Initial(ApplicationContext applicationContext)
        {
            if (!applicationContext.Users.Any())
            {
                var users = new List<User>()
                {
                 new User()
                 {
                    Email = "admin@gmail.com",
                    FirstName = "Admin",
                    LastName = "1",
                    HashPassword = "l5GXDEwuEr1KIn7xxmlezlp3RNHqX2Xx7UxVZ2CISzYdeFajP0hETRIcjA==",
                    Salt = "qmlW1gSTUtaH0jkXclixNh67LYcSIQu7ljE03hhFMKuiffIXHUKwwdH0yQ=="//12345
                 },
                 new User()
                 {
                    Email = "techer_1@gmail.com",
                    FirstName = "Teacher",
                    LastName = "1",
                    HashPassword = "l5GXDEwuEr1KIn7xxmlezlp3RNHqX2Xx7UxVZ2CISzYdeFajP0hETRIcjA==",
                    Salt = "qmlW1gSTUtaH0jkXclixNh67LYcSIQu7ljE03hhFMKuiffIXHUKwwdH0yQ=="//12345
                 },
                 new User()
                 {
                    Email = "techer_2@gmail.com",
                    FirstName = "Teacher",
                    LastName = "2",
                    HashPassword = "l5GXDEwuEr1KIn7xxmlezlp3RNHqX2Xx7UxVZ2CISzYdeFajP0hETRIcjA==",
                    Salt = "qmlW1gSTUtaH0jkXclixNh67LYcSIQu7ljE03hhFMKuiffIXHUKwwdH0yQ=="//12345
                 },
                 new User()
                 {
                    Email = "learner_1@gmail.com",
                    FirstName = "Student",
                    LastName = "1",
                    HashPassword = "l5GXDEwuEr1KIn7xxmlezlp3RNHqX2Xx7UxVZ2CISzYdeFajP0hETRIcjA==",
                    Salt = "qmlW1gSTUtaH0jkXclixNh67LYcSIQu7ljE03hhFMKuiffIXHUKwwdH0yQ=="//12345
                 },
                 new User()
                 {
                    Email = "learner_2gmail.com",
                    FirstName = "Student",
                    LastName = "2",
                    HashPassword = "l5GXDEwuEr1KIn7xxmlezlp3RNHqX2Xx7UxVZ2CISzYdeFajP0hETRIcjA==",
                    Salt = "qmlW1gSTUtaH0jkXclixNh67LYcSIQu7ljE03hhFMKuiffIXHUKwwdH0yQ=="//12345
                 }
                };

                applicationContext.Users.AddRange(users);


                var roles = new List<Role>()
                {
                 new Role()
                 {
                    Name = "Admin",
                 },
                 new Role()
                 {
                    Name = "Teacher",
                 },
                 new Role()
                 {
                    Name = "Student",
                 },
                };

                applicationContext.Roles.AddRange(roles);
                applicationContext.SaveChanges();
            }
        }
    }
}
