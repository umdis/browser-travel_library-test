using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using BrowserTravel.Library.Entities.Models;
using BrowserTravel.Library.Infraestructure.Data;
using BrowserTravel.Library.Repository.Interfaces;

namespace BrowserTravel.Library.Repository.Repositories
{
    public class AccountRepository: Repository<User>, IAccountRepository
    {
        private readonly ApplicationDbContext _context;
        public AccountRepository(ApplicationDbContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(ApplicationDbContext));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userSignInDto"></param>
        /// <returns></returns>
        public async Task<User> SignIn(User user)
        {
            var usr = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
            return usr;
        }
    }
}
