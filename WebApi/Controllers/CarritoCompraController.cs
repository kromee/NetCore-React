using System;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	//[Route("api/[controller]")]
	//[ApiController]
	public class CarritoCompraController : BaseApiController
	{
		private readonly ICarritoCompraRepository _carrtioCompra;

		public CarritoCompraController(ICarritoCompraRepository carritoCompra) {

			_carrtioCompra = carritoCompra;
		}

		[HttpGet]
		public async Task<ActionResult<CarritoCompra>> GetCarritoCompra(string id) {

			var carrito = await _carrtioCompra.GetCarritoCompraAsync(id);

			return Ok(carrito ?? new CarritoCompra(id));

		}
		[HttpPost]
		public async Task<ActionResult<CarritoCompra>> UpdateCarritoCompra(CarritoCompra carritoParametro) {
			var carritoActualizado = await _carrtioCompra.UpdateCarritoCompraAsync(carritoParametro);
			return Ok(carritoActualizado);


		}
		[HttpDelete]
		public async Task DeleteCarritoCompra(string id) {
			await _carrtioCompra.DeleteCarritoCompraAsync(id);
		}
    }
}

