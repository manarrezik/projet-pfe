using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Models;

namespace UserManagement.Repositories
{
    public interface IRoleRepository
{
    Task<IEnumerable<Role>> GetAllAsync();
    Task<Role> GetByIdAsync(int id);
    Task<Role> CreateAsync(Role role);
    Task UpdateAsync(Role role);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
    Task<bool> LibelleExistsAsync(string libelle, int? excludeId = null);
    Task<Role> GetRoleByLibelleAsync(string libelle); // Ajout important
}

}

