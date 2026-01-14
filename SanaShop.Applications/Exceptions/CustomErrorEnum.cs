using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanaShop.Applications.Exceptions
{
    public enum CustomErrorEnum
    {
        CUSTOM_400, // Bad Request
        CUSTOM_400_WITH_CAUSE,
        CUSTOM_401, // Unauthorized
        CUSTOM_401_WITH_CAUSE,
        CUSTOM_403, // Forbidden
        CUSTOM_403_WITH_CAUSE,
        CUSTOM_404, // Not Found
        CUSTOM_404_WITH_CAUSE,
        CUSTOM_500, // Internal Server Error
        CUSTOM_500_WITH_CAUSE
    }

    public static class CustomErrorEnumExtensions
    {
        public static string ShowError(this CustomErrorEnum oCustomErrorEnum)
        {
            return oCustomErrorEnum switch
            {
                CustomErrorEnum.CUSTOM_400 => "Le paramètre est erroné.", // Bad Request
                CustomErrorEnum.CUSTOM_400_WITH_CAUSE => "Le paramètre est erroné : {0}",
                CustomErrorEnum.CUSTOM_401 => "Accès non autorisé.", // Unauthorized
                CustomErrorEnum.CUSTOM_401_WITH_CAUSE => "Accès non autorisé : {0}",
                CustomErrorEnum.CUSTOM_403 => "Accès interdit.", // Forbidden
                CustomErrorEnum.CUSTOM_403_WITH_CAUSE => "Accès interdit : {0}",
                CustomErrorEnum.CUSTOM_404 => "Aucun résultat trouvé.", // Not Found
                CustomErrorEnum.CUSTOM_404_WITH_CAUSE => "Aucun résultat trouvé : {0}",
                CustomErrorEnum.CUSTOM_500 => "Une erreur serveur est survennue.", // Internal Server Error
                CustomErrorEnum.CUSTOM_500_WITH_CAUSE => "Une erreur serveur est survennue : {0}",
                _ => "Erreur inconnue." // Unknown Error
            };
        }
    }
}
