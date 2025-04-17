using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Data;
using UserManagement.Models;

namespace UserManagement.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _context;
        
        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await _context.Roles.ToListAsync();
        }
        
        public async Task<Role> GetByIdAsync(int id)
        {
            return await _context.Roles.FindAsync(id);
        }
        
        public async Task<Role> CreateAsync(Role role)
        {
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();
            return role;
        }
        
        public async Task UpdateAsync(Role role)
        {
            _context.Entry(role).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        
        public async Task DeleteAsync(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role != null)
            {
                _context.Roles.Remove(role);
                await _context.SaveChangesAsync();
            }
        }
        
        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Roles.AnyAsync(r => r.idrole == id);
        }
        
        public async Task<bool> LibelleExistsAsync(string libelle, int? excludeId = null)
        {
            if (excludeId.HasValue)
                return await _context.Roles.AnyAsync(r => r.libelle == libelle && r.idrole != excludeId);
            
            return await _context.Roles.AnyAsync(r => r.libelle == libelle);
        }
        public async Task<Role> GetRoleByLibelleAsync(string libelle)
{
    return await _context.Roles.FirstOrDefaultAsync(r => r.libelle == libelle);
}

    }
}

