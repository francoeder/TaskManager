using AutoFixture;
using AutoMapper;
using Moq;
using Moq.AutoMock;

namespace TaskManager.Application.Tests.Base
{
    public class BaseTests<TClass> where TClass : class
    {
        private TClass _instance;

        private readonly Fixture _fixture;

        private readonly AutoMocker _autoMocker;

        public BaseTests()
        {
            _fixture = new Fixture();
            _autoMocker = new AutoMocker();

            var mapperConfiguration = new MapperConfiguration(x =>
                x.AddMaps(typeof(Mapping.TaskProfile).Assembly));

            _autoMocker.Use((IMapper)new Mapper(mapperConfiguration));

            _instance = _autoMocker.CreateInstance<TClass>();
        }

        protected TClass Instance => _instance;

        protected Fixture Fixture => _fixture;

        protected Mock<TService> GetMock<TService>() where TService : class
        {
            return _autoMocker.GetMock<TService>();
        }
    }
}
