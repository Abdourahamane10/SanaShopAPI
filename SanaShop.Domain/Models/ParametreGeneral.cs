using SanaShop.Domain.Base;
using SanaShop.Domain.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanaShop.Domain.Models
{
    public class ParametreGeneral : BaseEntity
    {
        #region propriétés

        public string NomSociete { get; private set; } = default!;
        public Telephone MobileContact { get; private set; } = default!;
        public Telephone FixeContact { get; private set; } = default!;
        public Email EmailContact { get; private set; } = default!;
        public string? ParagrapheEntete { get; private set; }
        public string? ParagraphePiedDePage { get; private set; }
        public string? ParagraphePageAccueil { get; private set; }
        public string? ParagrapheAPropos { get; private set; }
        public string? UrlLogoSociete { get; private set; }

        #endregion propriétés

        #region constructeurs

        private ParametreGeneral()
        {
        }

        public ParametreGeneral(string nomSociete, Telephone mobileContact, Telephone fixeContact, Email emailContact)
        {
            DefinirOuModifierNomSociete(nomSociete);
            MobileContact = mobileContact ?? throw new ArgumentNullException(nameof(mobileContact));
            FixeContact = fixeContact ?? throw new ArgumentNullException(nameof(fixeContact));
            EmailContact = emailContact ?? throw new ArgumentNullException(nameof(emailContact));
        }
        #endregion constructeurs

        #region méthodes métier
        public void DefinirOuModifierNomSociete(string sNomSociete)
        {
            if (String.IsNullOrWhiteSpace(sNomSociete))
            {
                throw new ArgumentException("Le nom de la société ne peut pas être null ou vide.", nameof(sNomSociete));
            }

            NomSociete = sNomSociete;
        }
        #endregion méthodes métier

        #region Méthodes publiques
        public void DefinirOuModifierParagrapheEntete(string? paragrapheEntete)
        {
            ParagrapheEntete = paragrapheEntete;
        }

        public void DefinirOuModifierParagraphePiedDePage(string? paragraphePiedDePage)
        {
            ParagraphePiedDePage = paragraphePiedDePage;
        }

        public void DefinirOuModifierParagraphePageAccueil(string? paragraphePageAccueil)
        {
            ParagraphePageAccueil = paragraphePageAccueil;
        }

        public void DefinirOuModifierParagrapheAPropos(string? paragrapheAPropos)
        {
            ParagrapheAPropos = paragrapheAPropos;
        }

        public void DefinirOuModifierUrlLogoSociete(string? urlLogoSociete)
        {
            UrlLogoSociete = urlLogoSociete;
        }

        public void ModifierMobileContact(string sIndicatifMobile, string sNumMobile)
        {
            MobileContact = new Telephone(sIndicatifMobile, sNumMobile);
        }

        public void ModifierFixeContact(string sIndicatifFixe, string sNumFixe)
        {
            FixeContact = new Telephone(sIndicatifFixe, sNumFixe);
        }

        public void ModifierEmailContact(string sEmailContact)
        {
            EmailContact = new Email(sEmailContact);
        }

        public void ModifierParagraphes(string paragrapheEntete, string paragraphePiedDePage,
            string paragraphePageAccueil, string paragrapheAPropos)
        {
            DefinirOuModifierParagrapheEntete(paragrapheEntete);
            DefinirOuModifierParagraphePiedDePage(paragraphePiedDePage);
            DefinirOuModifierParagraphePageAccueil(paragraphePageAccueil);
            DefinirOuModifierParagrapheAPropos(paragrapheAPropos);
        }

        public void ModifierUrlLogoSociete(string urlLogoSociete)
        {
            UrlLogoSociete = urlLogoSociete;
        }

        public void MettreAjourParametreGeneral(string sNomSociete, string sIndicatifPaysMobile, string sNumMobile, 
            string sIndicatifPaysFixe, string sNumFixe, string sAdresseEmail, string sParagrapheEntete,
            string sParagraphePiedDePage, string sParagraphePageAccueil, string sParagrapheAPropos, string sUrlLogoSociete)
        {
            DefinirOuModifierNomSociete(sNomSociete);
            ModifierMobileContact(sIndicatifPaysMobile, sNumMobile);
            ModifierFixeContact(sIndicatifPaysFixe, sNumFixe);
            ModifierEmailContact(sAdresseEmail);
            ModifierParagraphes(sParagrapheEntete, sParagraphePiedDePage, sParagraphePageAccueil, sParagrapheAPropos);
            ModifierUrlLogoSociete(sUrlLogoSociete);
        }
        #endregion Méthodes publiques
    }
}
