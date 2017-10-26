namespace GameStore.App.Services
{
    using System.Linq;
    using GameStore.App.Data;
    using GameStore.App.Data.Models;
    using GameStore.App.Services.Contracts;
    public class UserService : IUserService
    {
        public bool Create(string email, string fullName, string password)
        {
            using (var db = new GameStoreDbContext())
            {
                if (db.Users.Any(u => u.Email == email))
                {
                    return false;
                }

                User user = new User
                {
                    Email = email,
                    FullName = fullName,
                    Password = password
                };
                
                if (!db.Users.Any())
                {
                    user.IsAdmin = true;
                }
                db.Users.Add(user);
                db.SaveChanges();
                return true;
            }
        }

        public bool Exists(string email, string password)
        {
            using (var db = new GameStoreDbContext())
            {
                return db.Users
                    .Any(e => e.Email == email && e.Password == password);
            }
        }
    }
}