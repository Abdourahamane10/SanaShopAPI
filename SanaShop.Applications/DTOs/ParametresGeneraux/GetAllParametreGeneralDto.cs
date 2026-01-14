using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanaShop.Applications.DTOs.ParametresGeneraux
{
    public record GetAllParametreGeneralDto 
    (
        int Id,
        string Raison_sociale,
        string CodePays_telephone_mobile,
        string Numero_telephone_mobile,
        string CodePays_telephone_fixe,
        string Numero_telephone_fixe,
        string Email,
        string? Texte_Entete,
        string? Texte_Pied_De_Page,
        string? Texte_PageAccueil,
        string? Texte_APropos,
        string? UrlLogo
    );
}
