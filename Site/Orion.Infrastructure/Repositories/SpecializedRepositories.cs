using Microsoft.EntityFrameworkCore;
using Orion.Core.Interfaces;
using Orion.Core.Models;
using Orion.Infrastructure.Data;
using System.Linq.Expressions;

namespace Orion.Infrastructure.Repositories
{
    public class NoteRepository : Repository<Note>, INoteRepository
    {
        public NoteRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Note>> FindAsync(Expression<Func<Note, bool>> predicate)
        {
            return await _dbSet
                .Include(n => n.CreatedBy)
                .Include(n => n.Group)
                .Where(predicate)
                .ToListAsync();
        }

        public override async Task<Note?> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(n => n.CreatedBy)
                .Include(n => n.Group)
                .FirstOrDefaultAsync(n => n.Id == id);
        }
    }

    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        public GroupRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Group>> FindAsync(Expression<Func<Group, bool>> predicate)
        {
            return await _dbSet
                .Include(g => g.UserGroups)
                .Where(predicate)
                .ToListAsync();
        }

        public override async Task<Group?> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(g => g.UserGroups)
                .Include(g => g.Tasks)
                .Include(g => g.Notes)
                .FirstOrDefaultAsync(g => g.Id == id);
        }
    }

    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<IEnumerable<ApplicationUser>> FindAsync(Expression<Func<ApplicationUser, bool>> predicate)
        {
            return await _context.Users.Where(predicate).ToListAsync();
        }

        public async Task<ApplicationUser?> GetByIdAsync(string id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task AddAsync(ApplicationUser entity)
        {
            await _context.Users.AddAsync(entity);
        }

        public async Task UpdateAsync(ApplicationUser entity)
        {
            _context.Users.Update(entity);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(ApplicationUser entity)
        {
            _context.Users.Remove(entity);
            await Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

    public class UserGroupRepository : Repository<UserGroup>, IUserGroupRepository
    {
        public UserGroupRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<UserGroup>> FindAsync(Expression<Func<UserGroup, bool>> predicate)
        {
            return await _dbSet
                .Include(ug => ug.User)
                .Include(ug => ug.Group)
                .Where(predicate)
                .ToListAsync();
        }
    }
} 