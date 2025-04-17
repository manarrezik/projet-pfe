using System.ComponentModel.DataAnnotations;

namespace UserManagement.DTOs
{
    public class UpdateRoleDto
    {
        [Required]
        [StringLength(255)]
        public string Libelle { get; set; }
    }
}

