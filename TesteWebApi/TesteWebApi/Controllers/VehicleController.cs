using Microsoft.AspNetCore.Mvc;
using TesteWebApi.Domain.Models;
using TesteWebApi.Domain.Models.Dto;
using TesteWebApi.Service.Interfaces;

namespace TesteWebApi.Controllers
{
    ///<Summary>
    /// VehicleController
    ///</Summary>
    [Route("api/v1/vehicle")]
    public class VehicleController : Controller
    {
        private readonly IUnitOfWorkService _serviceUoW;

        ///<Summary>
        /// VehicleController constructor
        ///</Summary>
        public VehicleController(IUnitOfWorkService serviceUoW)
        {
            _serviceUoW = serviceUoW;
        }

        /// <summary>
        /// Endpoint responsible for creating a space for car
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> CreateSpaceCar([FromBody] VehicleDto vehicleDto, int id)
        {
            try
            {
                Parking? parking = await _serviceUoW.ParkingService.UpdateSpacesParking(vehicleDto, id);
                return Ok(new
                {
                    mensagem = $"Cadastro de estacionamento realizado com sucesso."
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "Houve um erro ao cadastrar o estacionamento! " + ex + ""
                });
            }
        }

        /// <summary>
        /// Endpoint responsible for listing vehicles
        /// </summary>
        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<VehicleDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllVehicles()
        {
            try
            {
                var parkings = await _serviceUoW.VehicleService.GetAllVehicles();
                return Ok(parkings);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "Houve um erro ao carregar os estacionamentos " + ex + ""
                });
            }
        }

        /// <summary>
        /// Listing all vans in parking
        /// </summary>
        [HttpGet("vans")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<VehicleDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllVanForParking(int id)
        {
            try
            {
                var parkings = await _serviceUoW.VehicleService.GetAllVanForParking(id);
                return Ok(parkings);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "Houve um erro ao carregar os estacionamentos " + ex + ""
                });
            }
        }
    }
}