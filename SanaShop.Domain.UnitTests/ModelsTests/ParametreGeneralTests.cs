using FluentAssertions;
using SanaShop.Domain.Models;
using SanaShop.Domain.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanaShop.Domain.UnitTests.ModelsTests
{
    public class ParametreGeneralTests
    {
        #region Méthodes privées
        private ParametreGeneral CreateValidParametreGeneral()
        {
            string nomSociete = "SanaShop";
            Telephone mobileContact = Telephone.Create("+33", "0612345677");
            Telephone fixeContact = Telephone.Create("+33", "0147258369");
            Email emailContact = new Email("test@gmail.com");

            return new ParametreGeneral(nomSociete, mobileContact, fixeContact, emailContact);
        }
        #endregion Méthodes privées

        #region ConstructeurTests
        [Fact]
        public void Constructor_ShouldCreateParametreGeneral_WhenDataIsValid()
        {
            // Arrange & Act
            var parametreGeneral = CreateValidParametreGeneral();

            //Assert
            parametreGeneral.NomSociete.Should().Be("SanaShop");
            parametreGeneral.MobileContact.IndicatifPays.Should().Be("+33");
            parametreGeneral.MobileContact.NumTelephone.Should().Be("0612345677");
            parametreGeneral.MobileContact.E164.Should().Be("+33612345677");
            parametreGeneral.FixeContact.IndicatifPays.Should().Be("+33");
            parametreGeneral.FixeContact.NumTelephone.Should().Be("0147258369");
            parametreGeneral.FixeContact.E164.Should().Be("+33147258369");
            parametreGeneral.EmailContact.Adresse.Should().Be("test@gmail.com");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void Constructor_ShouldThrowArgumentException_WhenNomSocieteIsNullOrEmptyOrWhitespace(string sNomSociete)
        {
            // Arrange
            Action act = () => new ParametreGeneral(
                sNomSociete!,
                Telephone.Create("+33", "0612345677"),
                Telephone.Create("+33", "0147258369"),
                new Email("test@gamil.com")
            );

            // Act & Assert
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Constructor_ShouldThrowArgumentNullExcpetion_WhenMobileContactIsNull()
        {
            //Arrange
            Action act = () => new ParametreGeneral(
                "SanaShop",
                null!,
                Telephone.Create("+33", "0147258369"),
                new Email("test@gamil.com")
            );

            // Act & Assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Constructor_ShouldThrowArgumentNullExcpetion_WhenFixeContactIsNull()
        {
            //Arrange
            Action act = () => new ParametreGeneral(
                "SanaShop",
                Telephone.Create("+33", "0612345677"),
                null!,
                new Email("test@gamil.com")
            );

            // Act & Assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Constructor_ShouldThrowArgumentNullException_WhenEmailContactIsNull()
        {
            //Arrange
            Action act = () => new ParametreGeneral(
                "SanaShop",
                Telephone.Create("+33", "0612345677"),
                Telephone.Create("+33", "0147258369"),
                null!
            );

            // Act & Assert
            act.Should().Throw<ArgumentNullException>();
        }
        #endregion ConstructeurTests

        #region Méthodes métier tests
        [Fact]
        public void DefinirOuModifierNomSociete_ShouldUpdateNomSociete_WhenDataIsValid()
        {
            //Arrange
            var parametreGeneral = CreateValidParametreGeneral();

            //Act
            parametreGeneral.DefinirOuModifierNomSociete("NouveauNom");

            //Assert
            parametreGeneral.NomSociete.Should().Be("NouveauNom");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void DefinirOuModifierNomSociete_ShouldThrowArgumentException_WhenNomSocieteIsNullOrEmptyOrWhitespace
            (string sNomSociete)
        {
            //Arrange
            var parametreGeneral = CreateValidParametreGeneral();

            //Act
            Action act = () => parametreGeneral.DefinirOuModifierNomSociete(sNomSociete!);

            //Assert
            act.Should().Throw<ArgumentException>();
        }
        #endregion Méthodes métier tests

        #region Méthodes publiques tests
        [Fact]
        public void ModifierParagrapheEntete_ShhouldUpdatePragrapheEntete()
        {
            //Arrange
            var parametreGeneral = CreateValidParametreGeneral();

            //Act
            parametreGeneral.ModifierParagrapheEntete("Nouveau paragraphe d'entête");

            //Assert
            parametreGeneral.ParagrapheEntete.Should().Be("Nouveau paragraphe d'entête");
        }

        [Fact]
        public void ModifierParagraphePiedDePage_ShouldUpdateParagraphePiedDePage()
        {
            //Arrange
            var parametreGeneral = CreateValidParametreGeneral();

            //Act
            parametreGeneral.ModifierParagraphePiedDePage("Nouveau paragraphe de pied de page");

            //Assert
            parametreGeneral.ParagraphePiedDePage.Should().Be("Nouveau paragraphe de pied de page");
        }

        [Fact]
        public void ModifierParagraphePageAccueil_ShouldUpdateParagraphePageAccueil()
        {
            //Arrange
            var parametreGeneral = CreateValidParametreGeneral();

            //Act
            parametreGeneral.ModifierParagraphePageAccueil("Nouveau paragraphe de page accueil");

            //Assert
            parametreGeneral.ParagraphePageAccueil.Should().Be("Nouveau paragraphe de page accueil");
        }

        [Fact]
        public void ModifierParagrapheAPropos_ShouldUpdateParagrapheAPropos()
        {
            //Arrange
            var parametreGeneral = CreateValidParametreGeneral();

            //Act
            parametreGeneral.ModifierParagrapheAPropos("Nouveau paragraphe A propos");

            //Assert
            parametreGeneral.ParagrapheAPropos.Should().Be("Nouveau paragraphe A propos");
        }

        [Fact]
        public void ModifierUrlLogoSociete_ShouldUpdateUrlLogoSociete()
        {
            //Arrange
            var parametreGeneral = CreateValidParametreGeneral();

            //Act
            parametreGeneral.ModifierUrlLogoSociete("nouveau-logo.png");

            //Assert
            parametreGeneral.UrlLogoSociete.Should().Be("nouveau-logo.png");
        }

        [Fact]
        public void ModifierMobileContact_ShouldUpdateMobileContact()
        {
            //Arrange
            var parametreGeneral = CreateValidParametreGeneral();

            //Act
            parametreGeneral.ModifierMobileContact("+33", "0612345677");

            //Assert
            parametreGeneral.MobileContact.IndicatifPays.Should().Be("+33");
            parametreGeneral.MobileContact.NumTelephone.Should().Be("0612345677");
            parametreGeneral.MobileContact.E164.Should().Be("+33612345677");
        }

        [Fact]
        public void ModifierFixeContact_ShouldUpdateFixeContact()
        {
            //Arrange
            var parametreGeneral = CreateValidParametreGeneral();

            //Act
            parametreGeneral.ModifierFixeContact("+33", "0112345677");

            //Assert
            parametreGeneral.FixeContact.IndicatifPays.Should().Be("+33");
            parametreGeneral.FixeContact.NumTelephone.Should().Be("0112345677");
            parametreGeneral.FixeContact.E164.Should().Be("+33112345677");
        }

        [Fact]
        public void ModifierEmailContact_ShouldUpdateEmailContact()
        {
            //Arrange
            var parametreGeneral = CreateValidParametreGeneral();

            //Act
            parametreGeneral.ModifierEmailContact("contact@sanashop.com");

            //Assert
            parametreGeneral.EmailContact.Adresse.Should().Be("contact@sanashop.com");
        }

        [Fact]
        public void ModifierParagraphes_ShouldUpdateAllParagraphes()
        {
            //Arrange
            var parametreGeneral = CreateValidParametreGeneral();

            //Act
            parametreGeneral.ModifierParagraphes(
                "Nouveau paragraphe d'entête",
                "Nouveau paragraphe de pied de page",
                "Nouveau paragraphe de page accueil",
                "Nouveau paragraphe A propos"
            );

            //Assert
            parametreGeneral.ParagrapheEntete.Should().Be("Nouveau paragraphe d'entête");
            parametreGeneral.ParagraphePiedDePage.Should().Be("Nouveau paragraphe de pied de page");
            parametreGeneral.ParagraphePageAccueil.Should().Be("Nouveau paragraphe de page accueil");
            parametreGeneral.ParagrapheAPropos.Should().Be("Nouveau paragraphe A propos");
        }

        [Fact]
        public void MettreAjourParametreGeneral_ShouldUpdateAllProperties_WhenDataIsValid()
        {
            //Arrange
            var parametreGeneral = CreateValidParametreGeneral();

            //Act
            parametreGeneral.MettreAjourParametreGeneral(
                "NouveauNom",
                "+33", "0612345677",
                "+33", "0112345666",
                "contact@sanashop.com",
                "Nouveau paragraphe d'entête",
                "Nouveau paragraphe de pied de page",
                "Nouveau paragraphe de page accueil",
                "Nouveau paragraphe A propos",
                "nouveauLogo.png"
            );

            //Assert
            parametreGeneral.NomSociete.Should().Be("NouveauNom");
            parametreGeneral.MobileContact.IndicatifPays.Should().Be("+33");
            parametreGeneral.MobileContact.NumTelephone.Should().Be("0612345677");
            parametreGeneral.MobileContact.E164.Should().Be("+33612345677");
            parametreGeneral.FixeContact.IndicatifPays.Should().Be("+33");
            parametreGeneral.FixeContact.NumTelephone.Should().Be("0112345666");
            parametreGeneral.FixeContact.E164.Should().Be("+33112345666");
            parametreGeneral.EmailContact.Adresse.Should().Be("contact@sanashop.com");
            parametreGeneral.ParagrapheEntete.Should().Be("Nouveau paragraphe d'entête");
            parametreGeneral.ParagraphePiedDePage.Should().Be("Nouveau paragraphe de pied de page");
            parametreGeneral.ParagraphePageAccueil.Should().Be("Nouveau paragraphe de page accueil");
            parametreGeneral.ParagrapheAPropos.Should().Be("Nouveau paragraphe A propos");
            parametreGeneral.UrlLogoSociete.Should().Be("nouveauLogo.png");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void MettreAjourParametreGeneral_ShouldThrowArgumentException_WhenNomSocieteIsNullOrEmptyOrWhitespace
            (string sNomSociete)
        {
            //Arrange
            var parametreGeneral = CreateValidParametreGeneral();

            //Act
            Action act = () => parametreGeneral.MettreAjourParametreGeneral(
                sNomSociete!,
                "+33", "0612345677",
                "+33", "0112345666",
                "contact@sanashop.com",
                "Nouveau paragraphe d'entête",
                "Nouveau paragraphe de pied de page",
                "Nouveau paragraphe de page accueil",
                "Nouveau paragraphe A propos",
                "nouveauLogo.png"
            );

            //Assert
            act.Should().Throw<ArgumentException>();
        }
        #endregion Méthodes publiques tests
    }
}
