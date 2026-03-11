using FluentValidation.TestHelper;
using SanaShop.Applications.Features.Commands.ParametresGeneraux;
using SanaShop.Applications.Features.Validators.ParametresGeneraux;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanaShop.Applications.UnitTests.ValidatorsTests
{
    public class CreateParametreGeneralCommandValidatorTests
    {
        #region Attributs

        private readonly CreateParametreGeneralCommandValidator _validator;

        #endregion Attributs

        #region Constructeurs
        public CreateParametreGeneralCommandValidatorTests()
        {
            _validator = new CreateParametreGeneralCommandValidator();
        }
        #endregion Constructeurs

        #region Méthodes privées
        private static CreateParametreGeneralCommand CreateValidCommand()
        {
            return new CreateParametreGeneralCommand
                (
                    NomSociete: "SanaShop",
                    CodePaysTelephoneMobile: "+33",
                    NumContactMobile: "0723456789",
                    CodePaysTelephoneFixe: "+33",
                    NumContactFixe: "0923456789",
                    EmailContact: "contact@sanashop.com",
                    TexteEntete: "Entete",
                    TextePiedDePage: "Pied",
                    TextePageAccueil: "Accueil",
                    TexteAPropos: "A propos",
                    UrlLogoSociete: "logo.png"
                );
        }
        #endregion Méthodes privées

        #region Méthodes de tests
        [Fact]
        public void Sould_Not_Have_Error_When_Command_Is_Valid()
        {
            //Arrange
            var command = CreateValidCommand();

            //Act
            var result = _validator.TestValidate(command);

            //Assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void Should_Have_Error_When_NomSociete_Is_Empty(string sNomSociete)
        {
            //Arrange
            var command = CreateValidCommand() with { NomSociete = sNomSociete };

            //Act
            var result = _validator.TestValidate(command);

            //Assert
            result.ShouldHaveValidationErrorFor(p => p.NomSociete);
        }

        [Fact]
        public void Should_Have_Error_When_NomSociete_Is_Too_Long()
        {
            //Arrange
            var longNomSociete = new string('a', 201);
            var command = CreateValidCommand() with { NomSociete = longNomSociete };

            //Act
            var result = _validator.TestValidate(command);

            //Assert
            result.ShouldHaveValidationErrorFor(p => p.NomSociete);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("+12345")]
        public void Should_Have_Error_When_CodePaysTelephoneMobile_Is_Invalid(string sCodePays)
        {
            //Arrange
            var command = CreateValidCommand() with { CodePaysTelephoneMobile = sCodePays };

            //Act
            var result = _validator.TestValidate(command);

            //Assert
            result.ShouldHaveValidationErrorFor(p => p.CodePaysTelephoneMobile);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void Should_Have_Error_When_NumContactMobile_Is_Invalid(string sNumContactMobile)
        {
            //Arrange
            var command = CreateValidCommand() with { NumContactMobile = sNumContactMobile };

            //Act
            var result = _validator.TestValidate(command);

            //Assert
            result.ShouldHaveValidationErrorFor(p => p.NumContactMobile);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("+12345")]
        public void Should_Have_Error_When_CodePaysTelephoneFixe_Is_Ivalid(string sCodePays)
        {
            //Arrange
            var command =  CreateValidCommand() with { CodePaysTelephoneFixe = sCodePays };

            //Act
            var result = _validator.TestValidate(command);

            //Assert
            result.ShouldHaveValidationErrorFor(p => p.CodePaysTelephoneFixe);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void Should_Have_Error_When_NumContactFixe_Is_Invalid(string sNumContactFixe)
        {
            //Arrange
            var command = CreateValidCommand() with { NumContactFixe = sNumContactFixe };

            //Act
            var result = _validator.TestValidate(command);

            //Assert
            result.ShouldHaveValidationErrorFor(p => p.NumContactFixe);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("invalid-email")]
        public void Should_Have_Error_When_EmailContact_Is_Invalid(string sEmailContact)
        {
            //Arrange
            var command = CreateValidCommand() with { EmailContact = sEmailContact };

            //Act
            var result = _validator.TestValidate(command);

            //Assert
            result.ShouldHaveValidationErrorFor(p => p.EmailContact);

        }

        [Fact]
        public void Should_Have_Error_When_EmailContact_Is_Too_Long()
        {
            //Arrange
            var longEmailContact = new string('a', 101) + "@example.com";
            var command = CreateValidCommand() with { EmailContact = longEmailContact };

            //Act
            var result = _validator.TestValidate(command);

            //Assert
            result.ShouldHaveValidationErrorFor(p => p.EmailContact);
        }
        #endregion Méthodes de tests
    }
}
