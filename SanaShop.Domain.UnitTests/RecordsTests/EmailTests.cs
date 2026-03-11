using FluentAssertions;
using SanaShop.Domain.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanaShop.Domain.UnitTests.RecordsTests
{
    public class EmailTests
    {
        #region Constructeurs tests
        [Fact]
        public void Constructor_ShouldCreateEmail_WhenAdresseIsValid()
        {
            //Arrange & Act
            var email = new Email("contact@sanashop.com");

            //Assert
            email.Adresse.Should().Be("contact@sanashop.com");
        }

        [Fact]
        public void Constructor_ShouldThrowArgumentException_WhenAdresseIsInvalid()
        {
            //Arrange & Act
            Action act = () => new Email("invalid-email");

            //Assert
            act.Should().Throw<ArgumentException>();
        }
        #endregion Constructeurs tests
    }
}
