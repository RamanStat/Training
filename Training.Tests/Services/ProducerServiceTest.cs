using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using NUnit.Framework;
using Training.Data.Entities;
using Training.RA.Interfaces;
using Training.SDK.DTO;
using Training.SDK.EqualityComparers;
using Training.SDK.Services;
using Training.Service.Extensions;

namespace Training.Tests.Services
{
    public class ProducerServiceTest
    {
        private readonly List<ProducerDTO> _producers;
        private readonly IMapper _mapper;
        private readonly Mock<IProducerRepository> _mockProducerRepository;

        public ProducerServiceTest()
        {
            _producers = new List<ProducerDTO>()
            {
                new()
                {
                    Id = 1,
                    Address = "test",
                    Name = "test",
                    Phone = "test"
                },
                new()
                {
                    Id = 2,
                    Address = "test",
                    Name = "test",
                    Phone = "test"
                }
            };
            
            var producerFixture = new ProducerFixture();
            _mapper = MapperConfigurationExpression.CreateAutoMapper();

            _mockProducerRepository = new Mock<IProducerRepository>();

            _mockProducerRepository.Setup(pr => pr.GetAllAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.Run(() => producerFixture.GetProducers()));
            _mockProducerRepository.Setup(pr => pr.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
                .Returns(Task.Run(() => producerFixture.GetProducer(It.IsAny<int>())));
            _mockProducerRepository.Setup(pr => pr.CreateAsync(It.IsAny<Producer>(), It.IsAny<CancellationToken>()))
                .Returns(Task.Run(() => producerFixture.GetProducer(It.IsAny<int>())));
            _mockProducerRepository.Setup(pr => pr.UpdateAsync(It.IsAny<Producer>(), It.IsAny<CancellationToken>()))
                .Returns(Task.Run(() => producerFixture.GetProducer(It.IsAny<int>())));
            _mockProducerRepository.Setup(pr => pr.DeleteAsync(It.IsAny<Producer>(), It.IsAny<CancellationToken>()))
                .Returns(Task.Run(() => producerFixture.GetProducer(It.IsAny<int>())));
        }

        [Test]
        public async Task GetProducersAsync_InvokeMethod_GettingProducers()
        {
            //Arrange
            var expectedProducers = _producers;
            var producerService = new ProducerService(_mapper, _mockProducerRepository.Object);

            //Act
            var producers = await producerService.GetProducersAsync();

            //Assert
            Assert.That(expectedProducers, Is.EqualTo(producers).Using(new ProducerDTOEquilityComparer()));
        }

        [Test]
        public async Task GetProducerAsync_SentId_GettingProducerById()
        {
            //Arrange
            var expectedProducer = _producers[0];
            var producerService = new ProducerService(_mapper, _mockProducerRepository.Object);

            //Act
            var producer = await producerService.GetProducerAsync(1);

            //Assert
            Assert.That(expectedProducer, Is.EqualTo(producer).Using(new ProducerDTOEquilityComparer()));
        }

        [Test]
        public async Task CreateProducerAsync_SentRightProducer_GettingCreatedProducer()
        {
            //Arrange
            var expectedProducer = _producers[0];
            var producerService = new ProducerService(_mapper, _mockProducerRepository.Object);

            //Act
            var producer = await producerService.CreateProducerAsync(_producers[0]);

            //Assert
            Assert.That(expectedProducer, Is.EqualTo(producer).Using(new ProducerDTOEquilityComparer()));
        }

        [Test]
        public async Task UpdateProducerAsync_SentRightProducer_GettingUpdatedProducer()
        {
            //Arrange
            var expectedProducer = _producers[0];
            var producerService = new ProducerService(_mapper, _mockProducerRepository.Object);

            //Act
            var producer = await producerService.UpdateProducerAsync(_producers[0]);

            //Assert
            Assert.That(expectedProducer, Is.EqualTo(producer).Using(new ProducerDTOEquilityComparer()));
        }

        [Test]
        public async Task DeleteProducerAsync_SentId_GettingDeletedProducer()
        {
            //Arrange
            var expectedProducer = _producers[0];
            var producerService = new ProducerService(_mapper, _mockProducerRepository.Object);

            //Act
            var producer = await producerService.CreateProducerAsync(_producers[0]);

            //Assert
            Assert.That(expectedProducer, Is.EqualTo(producer).Using(new ProducerDTOEquilityComparer()));
        }

        [Test]
        public async Task DeleteProducerAsync_SentId_ThrowenNotFound()
        {
            //Arrange
            var expectedProducer = _producers[0];
            var producerService = new ProducerService(_mapper, _mockProducerRepository.Object);

            //Act
            var producer = await producerService.CreateProducerAsync(_producers[0]);

            //Assert
            Assert.That(expectedProducer, Is.EqualTo(producer).Using(new ProducerDTOEquilityComparer()));
        }
    }
}
