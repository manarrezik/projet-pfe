using System.ComponentModel.DataAnnotations;

namespace UserManagement.DTOs
{
    public class CreateUtilisateurDto
    {
        [Required]
        public int IdUnite { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Nom { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Prenom { get; set; }
        
        [StringLength(20)]
        public string NumTel { get; set; }
        
        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string Email { get; set; }
        
        [Required]
        [StringLength(255)]
        [MinLength(6)]
        public string MotPasse { get; set; }
        
        [Required]
        public int IdRole { get; set; }
    }
}