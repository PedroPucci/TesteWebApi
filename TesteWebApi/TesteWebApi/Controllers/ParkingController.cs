using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using TesteWebApi.Domain.Models;
using TesteWebApi.Domain.Models.Dto;
using TesteWebApi.Service.Interfaces;

namespace TesteWebApi.Controllers
{
    ///<Summary>
    /// ParkingController
    ///</Summary>
    [Route("api/v1/parking")]
    public class ParkingController : Controller
    {
        private readonly IUnitOfWorkService _serviceUoW;

        ///<Summary>
        /// ParkingController constructor
        ///</Summary>
        public ParkingController(IUnitOfWorkService serviceUoW)
        {
            _serviceUoW = serviceUoW;
        }

        /// <summary>
        /// Endpoint responsible for creating a parking
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> CreateParking([FromBody] ParkingDto parkingDto)
        {
            try
            {
                Parking parking = await _serviceUoW.ParkingService.AddParking(parkingDto);
                return Ok(new
                {
                    mensagem = $"Cadastro de estacionamento realizado com sucesso."
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "Houve um erro ao cadastrar o estacionamento! "+ ex + ""
                });
            }
        }

        /// <summary>
        /// Endpoint responsible for listing parkings
        /// </summary>
        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ParkingDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllParkings()
        {
            try
            {
                var parkings = await _serviceUoW.ParkingService.GetAllParkings();
                return Ok(parkings);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "Houve um erro ao carregar os estacionamentos "+ ex + ""
                });
            }
        }

        /// <summary>
        /// Endpoint responsible for return total number at parking
        /// </summary>
        [HttpGet("allSpaces")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ParkingDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> GetAllSpacesParking(int id)
        {
            try
            {
                int allSpaces = _serviceUoW.ParkingService.GetAllSpacesParking(id);
                return Task.FromResult<IActionResult>(Ok(allSpaces));
            }
            catch (Exception ex)
            {
                return Task.FromResult<IActionResult>(BadRequest(new
                {
                    mensagem = "Houve um erro ao carregar os estacionamentos " + ex + ""
                }));
            }
        }

        /// <summary>
        /// Endpoint responsible for return total empty number at parking
        /// </summary>
        [HttpGet("allSpacesEmpties")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ParkingDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> GetEmptySpacesParking(int id)
        {
            try
            {
                int allSpaces = _serviceUoW.ParkingService.GetEmptySpacesParking(id);
                return Task.FromResult<IActionResult>(Ok(allSpaces));
            }
            catch (Exception ex)
            {
                return Task.FromResult<IActionResult>(BadRequest(new
                {
                    mensagem = "Houve um erro ao carregar os estacionamentos " + ex + ""
                }));
            }
        }

        /// <summary>
        /// Parking is full
        /// </summary>
        [HttpGet("fullParking")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetFullParking(int id)
        {
            try
            {
                bool situationFullParking = _serviceUoW.ParkingService.GetFullParking(id);
                return Ok(situationFullParking);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Parking is empty
        /// </summary>
        [HttpGet("emptyParking")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetEmptyParking(int id)
        {
            try
            {
                bool situationFullParking = _serviceUoW.ParkingService.GetEmptyParking(id);
                return Ok(situationFullParking);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}