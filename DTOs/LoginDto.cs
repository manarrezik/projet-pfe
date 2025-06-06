using System.ComponentModel.DataAnnotations;

namespace UserManagement.DTOs
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        public string motpasse { get; set; }
    }
}