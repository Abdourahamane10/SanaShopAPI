using SanaShop.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanaShop.Domain.Models
{
    public class TypeInfo : BaseEntity
    {
        #region propriétés
        public string LibelleTypeInfo { get; protected set; } = default!;
        public int CodeTypeInfo { get; protected set; }
        #endregion propriétés

        #region constructeurs
        private TypeInfo()
        {
        }

        public TypeInfo(string libelleTypeInfo, int codeTypeInfo)
        {
            ChangerLibelle(libelleTypeInfo);
            ChangerCode(codeTypeInfo);
        }

        #endregion constructeurs

        #region méthodes métier
        public void ChangerLibelle(string libelle)
        {
            if (string.IsNullOrWhiteSpace(libelle))
            {
                throw new ArgumentException("Le libellé ne peut pas être vide ou nul.", nameof(libelle));
            }

            LibelleTypeInfo = libelle;
        }

        public void ChangerCode(int code)
        {
            if (code <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(code), "Le code doit être un entier strictement positif.");
            }

            CodeTypeInfo = code;
        }
        #endregion méthodes métier

        #region méthodes publiques
        public void MettreAjourTypeInfo(string libelle, int code)
        {
            ChangerLibelle(libelle);
            ChangerCode(code);
        }
        #endregion méthodes publiques
    }
}
