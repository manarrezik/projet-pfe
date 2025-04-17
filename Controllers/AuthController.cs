using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using UserManagement.DTOs;
using UserManagement.Services;
using UserManagement.Models;
using System.Threading.Tasks;

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUtilisateurService _utilisateurService;
        private readonly IJwtService _jwtService;

        public AuthController(IUtilisateurService utilisateurService, IJwtService jwtService)
        {
            _utilisateurService = utilisateurService;
            _jwtService = jwtService;
        }

       
[HttpPost("login")]
[AllowAnonymous]
public IActionResult Login([FromBody] LoginDto loginDto)
{
    try
    {
        // Cette méthode ne retourne un utilisateur que s'il a le rôle "Admin IT"
        var user = _utilisateurService.AuthenticateAdmin(loginDto.Email, loginDto.motpasse);

        if (user == null)
            return Unauthorized("❌ Accès refusé. Seuls les utilisateurs avec le rôle 'Admin IT' peuvent se connecter.");

        // Récupérer le libellé du rôle (qui sera toujours "Admin IT" ici)
        string roleLibelle = "Admin IT";

        // Générer le token
        var token = _jwtService.GenerateToken(user, roleLibelle);

        return Ok(new
        {
            token,
            userId = user.iduser,
            nom = user.nom,
            prenom = user.prenom,
            email = user.email,
            role = roleLibelle,
            isAdmin = true
        });
    }
    catch (InvalidOperationException ex)
    {
        return Unauthorized(ex.Message);
    }
}
        // ✅ Nouveau login pour Admin Métier & Responsable Unité
        [HttpPost("login-extended")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginExtended([FromBody] LoginDto loginDto)
        {
            var user = await _utilisateurService.GetByEmailAsync(loginDto.Email);

            if (user == null || user.motpasse != loginDto.motpasse)
                return Unauthorized("❌ Email ou mot de passe incorrect.");

            // Check if the account is deactivated
            if (user.Actif == "0")
            {
                return Unauthorized("Votre compte a été désactivé. Veuillez contacter l’administrateur.");
            }

            var roleName = await _utilisateurService.GetRoleNameByIdAsync(user.idrole);

            if (roleName != "Admin Métier" && roleName != "Responsable Unité")
                return Forbid("⛔ Accès refusé : vous n'avez pas le rôle requis.");

            var token = _jwtService.GenerateToken(user, roleName);

            return Ok(new
            {
                token,
                userId = user.iduser,
                nom = user.nom,
                prenom = user.prenom,
                email = user.email,
                role = roleName
            });
        }
    }
}
