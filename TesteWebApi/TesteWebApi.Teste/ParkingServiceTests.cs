using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage;
using Moq;
using TesteWebApi.Domain.Models;
using TesteWebApi.Domain.Models.Dto;
using TesteWebApi.Repository.Repository.Interfaces;
using TesteWebApi.Service;

namespace TesteWebApi.Teste
{
    public class ParkingServiceTests
    {
        [Fact(DisplayName = "Return All parkings")]
        public async Task GetAllParking_ReturnAll_Success()
        {
            var parkingsResult = new List<Parking>();
            var mockRepositoryUoW = new Mock<IRepositoryUoW>();

            mockRepositoryUoW.Setup(uow => uow.ParkingRepository.GetAllParkings())
                             .ReturnsAsync(parkingsResult);

            var parkingService = new ParkingService(mockRepositoryUoW.Object);
            var result = await parkingService.GetAllParkings();

            Assert.Equal(parkingsResult, result);
        }

        [Fact(DisplayName = "Create a parking as Success")]
        public async Task AddParking_Success()
        {
            var parking = CreateParking();
            var parkingDTO = CreateParkingDto();

            var mockRepositoryUoW = new Mock<IRepositoryUoW>();
            mockRepositoryUoW.Setup(uow => uow.ParkingRepository.AddParking(parking)).ReturnsAsync(parking);
            mockRepositoryUoW.Setup(uow => uow.SaveAsync());
            var mapper = new Mock<IMapper>();
            var mockDbContextTransaction = new Mock<IDbContextTransaction>();
            mockRepositoryUoW.Setup(uow => uow.BeginTransaction()).Returns(mockDbContextTransaction.Object);

            mapper.Setup(m => m.Map<ParkingDto, Parking>(parkingDTO)).Returns(parking);
            var withdrawalService = new ParkingService(mockRepositoryUoW.Object, mapper.Object);
            var result = await withdrawalService.AddParking(parkingDTO);

            Assert.Equal(parking, result);
            mockRepositoryUoW.Verify(uow => uow.ParkingRepository.AddParking(parking), Times.Once);
            mockRepositoryUoW.Verify(uow => uow.SaveAsync(), Times.Once);
        }

        public Parking CreateParking()
        {
            var parking = new Parking()
            {
                Id = 1,
                CreatedAt = DateTime.Now,
                Name = "Test",
                QtdSpacesBig = 10,
                QtdSpacesCar = 10,
                QtdSpacesMotorcycle = 10,
                TotalSpaceCar = 0,
                TotalSpaceMotorcycle = 0,
                TotalSpaceVan = 0
            };

            return parking;
        }

        public ParkingDto CreateParkingDto()
        {
            var parkingDto = new ParkingDto()
            {
                CreatedAt = DateTime.Now,
                Name = "Test",
                QtdSpacesBig = 10,
                QtdSpacesCar = 10,
                QtdSpacesMotorcycle = 10,
                TotalSpaceCar = 0,
                TotalSpaceMotorcycle = 0,
                TotalSpaceVan = 0
            };

            return parkingDto;
        }
    }
}