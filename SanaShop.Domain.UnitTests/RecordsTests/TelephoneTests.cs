using FluentAssertions;
using SanaShop.Domain.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanaShop.Domain.UnitTests.RecordsTests
{
    public class TelephoneTests
    {
        #region Méthodes metier tests
        [Fact]
        public void Create_ShouldCreateTelephone_WhenDataIsValid()
        {
            //Arrange & Act
            var telephone = Telephone.Create("+33", "0612345678");

            //Assert
            telephone.IndicatifPays.Should().Be("+33");
            telephone.NumTelephone.Should().Be("0612345678");
            telephone.E164.Should().Be("+33612345678");
        }

        [Theory]
        [InlineData("++", "0612345678")]
        [InlineData("+33", "0023456789")]
        public void Create_ShouldThrowArgumentException_WhenIndicatifPaysOrNumTelephoneIsInvalid(string sIndicatifPays, 
            string sNumTelephone)
        {
            //Arrange & Act
            Action act = () => Telephone.Create(sIndicatifPays, sNumTelephone);

            //Assert
            act.Should().Throw<ArgumentException>();
        }
        #endregion Méthodes metier tests
    }
}
