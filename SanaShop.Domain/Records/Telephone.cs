using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SanaShop.Domain.Records
{
    public sealed record Telephone
    {
        #region Propriétés

        public string IndicatifPays { get; } = default!;
        public string NumTelephone { get; } = default!;

        #endregion Propriétés

        #region Constructeurs
        private Telephone()
        {
        }

        public Telephone(string indicatifPays, string numTelephone)
        {
            ValiderCodePays(indicatifPays);
            IndicatifPays = indicatifPays;
            ValiderNumTelephone(numTelephone);
            NumTelephone = numTelephone;
        }
        #endregion Constructeurs

        #region Méthodes métier
        public static void ValiderCodePays(string indicatifPays)
        {
            if (String.IsNullOrWhiteSpace(indicatifPays) || indicatifPays.Length > 4 ||
                !Regex.IsMatch(indicatifPays, @"^\+[0-9]+$"))
            {
                throw new ArgumentException("Le coode est invalide", nameof(indicatifPays));
            }
        }

        public static void ValiderNumTelephone(string numTelephone)
        {
            if (String.IsNullOrWhiteSpace(numTelephone) || !Regex.IsMatch(numTelephone, @"[0-9]+$"))
            {
                throw new ArgumentException("Le numéro de téléphone n'est pas valide", nameof(numTelephone));
            }
        }
        #endregion Méthodes métier
    }
}
