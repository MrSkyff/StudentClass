using StudentClass.Data.Interfaces;
using StudentClass.Data.Repository;

namespace StudentClass
{
    public class ExtendedProgram
    {
        public static void WebApplicationBuilder(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IUser, UserRepository>();
            builder.Services.AddTransient<IUserInvite, UserInviteRepository>();
        }

    }
}
