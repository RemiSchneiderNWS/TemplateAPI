using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using TemplateAPI.Context;
using TemplateAPI.Models;
using TemplateAPI.Services;

namespace TemplateAPI.Controllers
{
    public class UtilisateursController : Controller
    {
        private readonly AppDbContext context;

        public UtilisateursController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpPost("CreateUser")]

        public async Task<ActionResult> CreateUser(Utilisateurs utilisateur)
        {
            if (utilisateur.email == "" || utilisateur.password == "")
            {
                return BadRequest("Tous les champs ne sont pas remplis");
            }
            string passwordHashed = Hashing.Sha512(utilisateur.password);
            // Vérifier le format de l'adresse e-mail
            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            if (!emailRegex.IsMatch(utilisateur.email))
            {

                return BadRequest("L'adresse e-mail n'est pas au bon format.");
            }

            var passwordRegex = new Regex(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])[a-zA-Z\d]{8,}$");
            if (!passwordRegex.IsMatch(utilisateur.password))
            {
                return BadRequest("Le mot de passe doit comporter au moins 8 caractères, avec au moins une minuscule, une majuscule et un chiffre.");
            }
       
            utilisateur.password = Hashing.Sha512(utilisateur.password);
            context.utilisateurs.Add(utilisateur);
            await context.SaveChangesAsync();
            return NoContent();

        }



        [HttpPost("login")]
        public ActionResult<Utilisateurs> Login(LogInfos loginfo)
        {
            if (loginfo.mail == "" || loginfo.password == "")
            {
                return BadRequest("Veuillez saisir les identifiants");
            }
            string passwordHashed = Hashing.Sha512(loginfo.password);
            // Vérifier le format de l'adresse e-mail
            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            if (!emailRegex.IsMatch(loginfo.mail))
            {

                return BadRequest("L'adresse e-mail n'est pas au bon format.");
            }

            // Utilisateurs utilisateur = context.utilisateurs.Where(utilisateurs => utilisateurs.email.Equals(loginfo.mail) && utilisateurs.password.Equals(passwordHashed)).FirstOrDefault();
            Utilisateurs? utilisateur = context.utilisateurs.FirstOrDefault(utilisateurs => utilisateurs.email.Equals(loginfo.mail) && utilisateurs.password.Equals(passwordHashed));
            if (utilisateur == null)
            {


                return BadRequest("Adresse e-mail ou mot de passe invalide.");
            }

           
          
            return utilisateur;
        }



    }
}
