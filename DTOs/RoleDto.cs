using System.ComponentModel.DataAnnotations;

namespace UserManagement.DTOs
{
    public class RoleDto
    {
        public int IdRole { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Libelle { get; set; }
    }
}

