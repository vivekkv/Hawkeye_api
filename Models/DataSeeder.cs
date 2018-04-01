using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Admin_Backend.Models;
using Admin_Backend.Models.DbModels;
using System.Linq;
using Admin_Backend.Models.Security;
using System.Text;

namespace Admin_Backend.Models
{
    public class DataSeeder
    {
        private ApveraDbContext _context;
        
        public DataSeeder(ApveraDbContext context) {

            _context = context;
        }

        public void SeedData()
        {
            AddUserDataSeeds();
            _context.SaveChanges();
        }

        private void AddUserDataSeeds()
        {
            if (!_context.Users.Any())
            {
                var passwordHash = SimpleHash.ComputeHash("Admin", "SHA1",  Encoding.ASCII.GetBytes("APVERA_SALT"));

                _context.Users.Add(new Users
                {
                    UserName = "Admin@apvera",
                    Password = passwordHash,
                    Salt     = "APVERA_SALT",
                    Name     = "Admin",
                    RoleId   = 1
                });
            }
        }
    }
}