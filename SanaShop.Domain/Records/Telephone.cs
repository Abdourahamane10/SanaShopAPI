using PhoneNumbers;
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

        public string E164 { get; } = default!;

        #endregion Propriétés

        #region Constructeurs
        private Telephone()
        {
        }

        private Telephone(string indicatifPays, string numTelephone, string e164)
        {
            this.IndicatifPays = indicatifPays;
            this.NumTelephone = numTelephone;
            this.E164 = e164;
        }
        #endregion Constructeurs

        #region Méthodes métier

        public static Telephone Create(string indicatifPays, string numTelephone)
        {
            var util = PhoneNumberUtil.GetInstance();

            try
            {
                var region = util.GetRegionCodeForCountryCode(int.Parse(indicatifPays.Replace("+", "")));

                if (region == null)
                {
                    throw new ArgumentException("Le code pays est invalide", nameof(indicatifPays));
                }

                var number = util.Parse(numTelephone, region);

                if (!util.IsValidNumber(number))
                {
                    throw new ArgumentException("Le numéro de téléphone n'est pas valide", nameof(numTelephone));
                }

                return new Telephone(indicatifPays, numTelephone, util.Format(number, PhoneNumberFormat.E164));
            }
            catch(Exception ex)
            {
                throw new ArgumentException("Le numéro de téléphone n'est pas valide", nameof(numTelephone), ex);    
            }
        }

        public override string ToString() => E164;
        #endregion Méthodes métier
    }
}
