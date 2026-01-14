using SanaShop.Domain.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanaShop.Applications.DTOs.ParametresGeneraux
{
    public class CreateParametreGeneralDto
    {
        public required string Raison_sociale { get; set; }
        public required string CodePays_telephone_mobile { get; set; }
        public required string Numero_telephone_mobile { get; set; }
        public required string CodePays_telephone_fixe { get; set; }
        public required string Numero_telephone_fixe { get; set; }
        public required string Email { get; set; }
        public string? Texte_Entete { get; set; } 
        public string? Texte_Pied_De_Page { get; set; } 
        public string? Texte_PageAccueil { get; set; }
        public string? Texte_APropos { get; set; } 
        public string? UrlLogo { get; set; } 
    }
}
