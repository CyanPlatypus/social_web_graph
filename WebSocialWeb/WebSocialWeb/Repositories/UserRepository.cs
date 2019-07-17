using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebSocialWeb.Models;
using WebSocialWeb.Models.Contexts;

namespace WebSocialWeb.Repositories
{
    public class UserRepository
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<User> _dbSet;

        public UserRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<User>();
        }

        public User Get(int id){
            
            return _dbSet
                .Include(u => u.Gender)
                .Include(u => u.PlaceOfBirth)
                .Include(u => u.Residence)
                .Include(u => u.Hobbies)
                .Include(u => u.Friends.Select(f => f.Friend))
                .FirstOrDefault(u => u.Id == id);
        }

        public List<User> GetAll()
        {
            return _dbSet.Include(u => u.Friends).ToList();
        }
    }
}