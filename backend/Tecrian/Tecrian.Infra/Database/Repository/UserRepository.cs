using Microsoft.EntityFrameworkCore;
using Tecrian.Domain.Entities;

namespace Tecrian.Infra.Database.Repository;

public class UserRepository : IRepository<User>
{
    private readonly TecrianDbContext _dbContext;
    private readonly DbSet<User> _dbSet;

    public UserRepository(TecrianDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<User>();
    }

    public async Task<User> AddAsync(User entity)
    {
        await _dbSet.AddAsync(entity);
        await _dbContext.SaveChangesAsync();

        User addedUser = await _dbSet.FirstAsync(t => t.Id == entity.Id);
        return entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        User? user = await _dbSet.FindAsync(id);
        if (user == null)
            return false;

        _dbSet.Remove(user);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _dbSet.Where(user => user.Id == id).FirstOrDefaultAsync();
    }

    public async Task<User?> GetByEmail(string? email)
    {
        return await _dbSet.Where(user => user.Email == email).FirstOrDefaultAsync();
    }

    public async Task<bool> UpdateAsync(User userToUpdate)
    {
        _dbSet.Update(userToUpdate);
        await _dbContext.SaveChangesAsync();

        return true;
    }
}
