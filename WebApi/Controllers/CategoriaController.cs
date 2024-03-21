using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
	public class CategoriaController: BaseApiController
	{
		private readonly IGenericRepository<Categoria> _categoriaRepository;

		public CategoriaController(IGenericRepository<Categoria> categoriaRepository) {
			_categoriaRepository = categoriaRepository;

        }
        [HttpGet]
		public async Task<ActionResult<IReadOnlyList<Categoria>>> GetCategoriaAll() {
		 return Ok(	await _categoriaRepository.GetAllAsync());
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Categoria>> getCategoriaById(int id) {
			return await _categoriaRepository.GetByIdAsync(id);
		}

	}
}

