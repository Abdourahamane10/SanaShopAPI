using FluentAssertions;
using Moq;
using SanaShop.Applications.Base;
using SanaShop.Applications.Features.Commands.ParametresGeneraux;
using SanaShop.Applications.Interfaces;
using SanaShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanaShop.Applications.UnitTests.handlersTests
{
    public class CreateParametreGeneralCommandHandlerTests
    {
        #region Propriétés privées
        private readonly Mock<IBaseRepository<ParametreGeneral>> _baseRepositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly CreateParametreGeneralCommandHandler _handler;
        #endregion Propriétés privées

        #region Constructeurs
        public CreateParametreGeneralCommandHandlerTests()
        {
            _baseRepositoryMock = new Mock<IBaseRepository<ParametreGeneral>>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _handler = new CreateParametreGeneralCommandHandler(_baseRepositoryMock.Object, _unitOfWorkMock.Object);
        }
        #endregion Constrcteurs

        #region Méthodes de tests
        [Fact]
        public async Task Handle_ShouldCreateParametreGeneral_AndReturnId()
        {
            // Arrange
            var command = new CreateParametreGeneralCommand(
                NomSociete: "SanaShop",
                CodePaysTelephoneMobile: "+33",
                NumContactMobile: "0612345678",
                CodePaysTelephoneFixe: "+33",
                NumContactFixe: "0147258369",
                EmailContact: "contact@sanashop.com",
                TexteEntete: "Contenu de l'entête",
                TextePiedDePage: "Contenu du pied de page",
                TextePageAccueil: "Contenu de la page accueil",
                TexteAPropos: "Contenu A propos",
                UrlLogoSociete: "logo.png"
            );

            ParametreGeneral entityCreated = null;

            _baseRepositoryMock
                .Setup(r => r.AddAsync(It.IsAny<ParametreGeneral>()))
                .Callback<ParametreGeneral>(e =>
                {
                    e.GetType().GetProperty("Id")!
                    .SetValue(e, 2); //Simule l'Id généré
                    entityCreated = e;
                })
                .Returns(Task.CompletedTask);

            _unitOfWorkMock
                .Setup(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().Be(2);

            entityCreated.Should().NotBeNull();

            _baseRepositoryMock.Verify(
                r => r.AddAsync(It.IsAny<ParametreGeneral>()),
                Times.Once
            );

            _unitOfWorkMock.Verify(
                u => u.SaveChangesAsync(It.IsAny<CancellationToken>()),
                Times.Once
            );
        }
        #endregion Méthodes de tests
    }
}
