using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.DTOs;

namespace UserManagement.Services
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleDto>> GetAllRolesAsync();
        Task<RoleDto> GetRoleByIdAsync(int id);
        Task<RoleDto> CreateRoleAsync(CreateRoleDto createDto);
        Task<RoleDto> UpdateRoleAsync(int id, UpdateRoleDto updateDto);
        Task DeleteRoleAsync(int id);
    }
}

