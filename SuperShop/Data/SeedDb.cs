using Microsoft.AspNetCore.Identity;
using SuperShop.Data.Entities;
using SuperShop.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        //private readonly UserManager<User> _userManager;
        private Random _random;
        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
            //_userManager = userManager;
            _random = new Random();
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            var user = await _userHelper.GetUserByEmailAsync("aandrecaldeira15@gmail.com");

            if(user == null)
            {
                user = new User
                {
                    FirstName = "André",
                    LastName = "Cabrita",
                    Email = "aandrecaldeira15@gmail.com",
                    UserName = "aandrecaldeira15@gmail.com",
                    PhoneNumber = "212313414"
                };

                var result = await _userHelper.AddUserAsync(user, "123456");

                if(result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }
            }


            if (!_context.Products.Any())
            {
                AddProduct("iPhone XYZ", user);
                AddProduct("EyeWatch S4", user);
                AddProduct("iPad 1231", user);
                AddProduct("iPhone ACB", user);
                await _context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name, User user)
        {
            _context.Products.Add(new Product
            {
                Name = name,
                Price = _random.Next(1000),
                IsAvaliable = true,
                Stock = _random.Next(100),
                User = user
            });
        }
    }
}
