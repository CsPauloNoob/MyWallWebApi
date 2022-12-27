using Microsoft.EntityFrameworkCore;
using MyWallWebApi.Domains.Models;
using MyWallWebApi.Insfrastructure.Data.Contexts;
using MyWallWebApi.Models;

namespace MyWallWebApi.Insfrastructure.Data.Repositories
{
    public class UserRepository
    {
        readonly SqliteContext _context;


        public UserRepository(SqliteContext sqliteContext)
        {
            _context = sqliteContext;
        }

        public async Task<List<ApplicationUser>> ListUsers()
        {
            var list = await _context.User.ToListAsync();

            return list;
        }


        public async Task<ApplicationUser> GetUser(string userId)
        {
            var post = await _context.User.FindAsync(userId);

            return post;
        }



        public async Task<ApplicationUser> NewUser(ApplicationUser User)
        {

            var result = await _context.User.AddAsync(User);
            await _context.SaveChangesAsync();

            return result.Entity;
        }



        public async Task<int> UpdateUser(ApplicationUser user)
        {
            _context.Entry(user).State = EntityState.Modified;

            return await _context.SaveChangesAsync();
        }



        public async Task<bool> DeleteUser(string userId)
        {
            var item = await _context.Post.FindAsync(userId);
            _context.Post.Remove(item);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}