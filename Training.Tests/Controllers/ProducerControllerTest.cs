using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Training.SDK.DTO;
using Training.SDK.Interfaces;
using Training.Service.Controllers;

namespace Training.Tests.Controllers
{
    public class ProducerControllerTest
    {
        private readonly ProducerController _producerController;
        private readonly Mock<IProducerService> _producerService;

        public ProducerControllerTest()
        {
            _producerService = new Mock<IProducerService>();
            _producerService.Setup(ps => ps.GetProducerAsync(It.IsAny<int>()))
                .Returns(Task.Run(It.IsAny<ProducerDTO>));
            _producerService.Setup(ps => ps.DeleteProducerAsync(It.IsAny<int>()))
                .Returns(Task.Run(It.IsAny<ProducerDTO>));
            _producerService.Setup(ps => ps.UpdateProducerAsync(It.IsAny<ProducerDTO>()))
                .Returns(Task.Run(It.IsAny<ProducerDTO>));
            _producerController = new ProducerController(_producerService.Object);
        }

        [Test]
        public async Task GetProducerById_SentNonExistingIdentifier_ReturnsNotFound()
        {
            //Act
            var producerDTO = await _producerController.GetProducerById(0);

            //Arrange
            Assert.IsInstanceOf<NotFoundResult>(producerDTO);
        }

        [Test]
        public async Task UpdateProducer_SentNull_ReturnsNotFound()
        {
            //Act
            var producerDTO = await _producerController.UpdateProducer(null);

            //Arrange
            Assert.IsInstanceOf<NotFoundResult>(producerDTO);
        }

        [Test]
        public async Task DeleteProducerById_SentNonExistingIdentifier_ReturnsNotFound()
        {
            //Act
            var producerDTO = await _producerController.DeleteProducerById(0);

            //Arrange
            Assert.IsInstanceOf<NotFoundResult>(producerDTO);
        }
    }
}
