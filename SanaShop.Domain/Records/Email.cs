using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanaShop.Domain.Records
{
    public sealed record Email
    {
        #region Propriétés

        public string Adresse { get; } = default!;

        #endregion Propriétés

        #region Constructeurs
        private Email()
        {
        }

        public Email(string adresse)
        {
            ValiderEmail(adresse);
            Adresse = adresse;
        }
        #endregion Constructeurs

        #region Méthodes métier
        public static void ValiderEmail(string adresse)
        {
            if (String.IsNullOrWhiteSpace(adresse) || !adresse.Contains("@"))
            {
                throw new ArgumentException("L'adresse email n'est pas valide", nameof(adresse));
            }
        }
        #endregion Méthodes métier

        #region Overrides
        public override string ToString() => Adresse;
        #endregion Overrides
    }
}
