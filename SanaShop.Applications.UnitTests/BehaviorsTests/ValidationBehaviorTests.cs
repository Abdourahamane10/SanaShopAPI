using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Moq;
using SanaShop.Applications.Common.Behaviors;
using SanaShop.Applications.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanaShop.Applications.UnitTests.BehaviorsTests
{
    public class ValidationBehaviorTests
    {
        #region Objet Request de test
        public record TestCommand(string Name) : IRequest<int>;
        #endregion Objet Request de test

        #region Méthodes de test
        [Fact]
        public async Task Handle_ShouldCallNext_WhenNoValidators()
        {
            //Arrange
            var validators = new List<IValidator<TestCommand>>();
            var request = new TestCommand("Test");
            var nextCalled = false;
            RequestHandlerDelegate<int> next = _ =>
            {
                nextCalled = true;
                return Task.FromResult(5);
            };
            var behavior = new ValidationBehavior<TestCommand, int>(validators);

            //Act
            var result = await behavior.Handle(request, next, CancellationToken.None);

            //Assert
            nextCalled.Should().BeTrue();
            result.Should().Be(5);
        }

        [Fact]
        public async Task Handle_ShouldCallNext_WhenValidationSucceeds()
        {
            //Arrange
            var validatorMock = new Mock<IValidator<TestCommand>>();
            var request = new TestCommand("Test");
            var nextCalled = false;
            RequestHandlerDelegate<int> next = _ =>
            {
                nextCalled = true;
                return Task.FromResult(10);
            };

            validatorMock.Setup(v => v.Validate(It.IsAny<ValidationContext<TestCommand>>()))
                .Returns(new ValidationResult());

            var behavior = new ValidationBehavior<TestCommand, int>(new[] {validatorMock.Object});

            //Act
            var result = await behavior.Handle(request, next, CancellationToken.None);

            //Assert
            nextCalled.Should().BeTrue();
            result.Should().Be(10);
        }

        [Fact]
        public async Task Handle_ShoulThrowCustomException_WhenValidationFails()
        {
            //Arrange
            var validatorMock = new Mock<IValidator<TestCommand>>();
            var request = new TestCommand("Test");
            var nextCalled = false;

            RequestHandlerDelegate<int> next = _ =>
            {
                nextCalled = true;
                return Task.FromResult(1);
            };

            var failure = new List<ValidationFailure>
            {
                new ValidationFailure("Name", "Name is required")
            };

            validatorMock.Setup(v => v.Validate(It.IsAny<ValidationContext<TestCommand>>()))
                .Returns(new ValidationResult(failure));

            var behavior = new ValidationBehavior<TestCommand, int>(new[] { validatorMock.Object });

            //Act
            Func<Task> act = () =>
            {
                return behavior.Handle(request, next, CancellationToken.None);
            };

            //Assert
            await act.Should().ThrowAsync<CustomException>();
            nextCalled.Should().BeFalse();
        }
        #endregion Méthodes de test
    }
}
