using SanaShop.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanaShop.Domain.Models
{
    public class Info : BaseEntity
    {
        #region Propriétés

        public string LibelleInfo { get; private set; } = default!;
        public DateTime DateCreation { get; init; }
        public DateTime? DateModification { get; protected set; }
        public DateTime DateDebut { get; private set; }
        public DateTime DateFin { get; private set; }
        public int TypeInfoId { get; private set; }
        public TypeInfo TypeInfo { get; private set; } = default!;

        #endregion Propriétés

        #region Constructeurs
        private Info()
        {
        }

        public Info(string libelleInfo, DateTime dateModification, DateTime dateDebut, 
            DateTime dateFin, TypeInfo typeInfo)
        {
            ChangerLibelleInfo(libelleInfo);
            DateCreation = DateTime.Now;
            ChangerDates(dateDebut, dateFin);
            AssocierTypeInfo(typeInfo);
        }
        #endregion Constructeurs

        #region Méthodes métier
        public void ChangerLibelleInfo(string libelle)
        {
            if (string.IsNullOrEmpty(libelle))
            {
                throw new ArgumentException("Le libellé ne peut pas être vide ou null.", nameof(libelle));
            }

            LibelleInfo = libelle;
        }

        public void ChangerDates(DateTime dateDebut, DateTime dateFin)
        {
            if (dateDebut > dateFin)
            {
                throw new ArgumentException("La date de début doit être antérieure ou égal à la date de fin.");
            }

            DateDebut = dateDebut;
            DateFin = dateFin;
        }

        public void AssocierTypeInfo(TypeInfo typeInfo)
        {
            TypeInfo = typeInfo ?? throw new ArgumentNullException(nameof(typeInfo), "Le TypeInfo ne peut pas être null.");
            TypeInfoId = typeInfo.Id;
        }
        #endregion Méthodes métier

        #region Méthodes publiques
        public void MettreAjourInfo(string libelleInfo, DateTime dateDebut,
            DateTime dateFin, TypeInfo typeInfo)
        {
            ChangerLibelleInfo(libelleInfo);
            DateModification = DateTime.Now;
            ChangerDates(dateDebut, dateFin);
            AssocierTypeInfo(typeInfo);
        }
        #endregion Méthodes publiques
    }
}
