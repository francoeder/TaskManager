using AutoFixture;
using Moq;
using TaskManager.Application.Tasks.Commands.CreateTask;
using TaskManager.Application.Tests.Base;
using TaskManager.Domain.Abstractions.Repositories;

namespace TaskManager.Application.Tests.CommandHandlers
{
    public class CreateTaskCommandHandlerTests : BaseTests<CreateTaskCommandHandler>, IDisposable
    {
        [Fact]
        public async Task Handle_WhenEverythingIsFine_ShouldReturnSuccess()
        {
            // Act
            var request = Fixture
                .Build<CreateTaskCommand>()
                .Create();

            // Arrange
            var response = await Instance.Handle(request, default);

            // Assert
            Assert.True(response.IsSuccess);
        }

        [Fact]
        public async Task Handle_WhenEverythingIsFine_ShouldPersistsCorrectObject()
        {
            // Act
            var request = Fixture
                .Build<CreateTaskCommand>()
                .Create();

            Domain.Entities.Task? taskEntityToValidate = null;
            GetMock<IRepository<Domain.Entities.Task>>()
                .Setup(repository =>
                    repository.AddAsync(It.IsAny<Domain.Entities.Task>(), It.IsAny<CancellationToken>()))
                .Callback<Domain.Entities.Task, CancellationToken>(
                    (entity, cancellationToken) => taskEntityToValidate = entity);

            // Arrange
            var response = await Instance.Handle(request, default);

            // Assert
            Assert.NotNull(taskEntityToValidate);
            Assert.Equal(request.Details, taskEntityToValidate.Details);
            Assert.Equal(request.Title, taskEntityToValidate.Title);
            Assert.Equal(request.DueDate, taskEntityToValidate.DueDate);
        }

        public void Dispose()
        {
            // Clean everything necessary here
        }
    }
}
