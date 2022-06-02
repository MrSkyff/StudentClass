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
                    FirstName = "John",
                    LastName = "Green",
                    HashPassword = "l5GXDEwuEr1KIn7xxmlezlp3RNHqX2Xx7UxVZ2CISzYdeFajP0hETRIcjA==",
                    Salt = "qmlW1gSTUtaH0jkXclixNh67LYcSIQu7ljE03hhFMKuiffIXHUKwwdH0yQ=="//12345
                 },
                 new User()
                 {
                    Email = "teacher_1@gmail.com",
                    FirstName = "Mike",
                    LastName = "Patison",
                    HashPassword = "l5GXDEwuEr1KIn7xxmlezlp3RNHqX2Xx7UxVZ2CISzYdeFajP0hETRIcjA==",
                    Salt = "qmlW1gSTUtaH0jkXclixNh67LYcSIQu7ljE03hhFMKuiffIXHUKwwdH0yQ=="//12345
                 },
                 new User()
                 {
                    Email = "teacher_2@gmail.com",
                    FirstName = "Greg",
                    LastName = "Woody",
                    HashPassword = "l5GXDEwuEr1KIn7xxmlezlp3RNHqX2Xx7UxVZ2CISzYdeFajP0hETRIcjA==",
                    Salt = "qmlW1gSTUtaH0jkXclixNh67LYcSIQu7ljE03hhFMKuiffIXHUKwwdH0yQ=="//12345
                 },
                 new User()
                 {
                    Email = "learner_1@gmail.com",
                    FirstName = "Bear",
                    LastName = "Grizly",
                    HashPassword = "l5GXDEwuEr1KIn7xxmlezlp3RNHqX2Xx7UxVZ2CISzYdeFajP0hETRIcjA==",
                    Salt = "qmlW1gSTUtaH0jkXclixNh67LYcSIQu7ljE03hhFMKuiffIXHUKwwdH0yQ=="//12345
                 },
                 new User()
                 {
                    Email = "learner_2@gmail.com",
                    FirstName = "Monika",
                    LastName = "Sudo",
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

                var userRoles = new List<UserRoles>()
                {
                 new UserRoles()
                 {
                     UserId = 1,
                     RoleId = 1,
                 },
                 new UserRoles()
                 {
                     UserId = 2,
                     RoleId = 2,
                 },
                 new UserRoles()
                 {
                     UserId = 3,
                     RoleId = 2,
                 },
                 new UserRoles()
                 {
                     UserId = 4,
                     RoleId = 3,
                 },
                 new UserRoles()
                 {
                     UserId = 5,
                     RoleId = 3,
                 },
                };

                applicationContext.UserRoles.AddRange(userRoles);

                applicationContext.SaveChanges();
            }
        }
    }
}
