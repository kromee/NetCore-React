using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;
using WebApi.Errors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class ProductoController : BaseApiController
    {
        private readonly IGenericRepository<Producto> _productoRepository;
        private readonly IMapper _mapper;

        public ProductoController(IGenericRepository<Producto> productoRepository, IMapper mapper) {
            _productoRepository = productoRepository;
            _mapper = mapper;
        }



        //api/producto
        [HttpGet]
        public async Task<ActionResult<Pagination<ProductoDTO>>> getProductos([FromQuery] ProductoSpecificationParams productoParams) {
            var spec = new ProductoWithCategoriaAndMarcaSpecification(productoParams);
            var productos = await _productoRepository.GetAllWithSpec(spec);

            var specCount = new ProductoForCountingSpecification(productoParams);
            var totalProductos = await _productoRepository.CountAsync(specCount);
            var rounded = Math.Ceiling(Convert.ToDecimal(totalProductos / productoParams.PageSize));
            var totalPages = Convert.ToInt32(rounded);

            var data = _mapper.Map<IReadOnlyList<Producto>, IReadOnlyList<ProductoDTO>>(productos);


            return Ok(
                new Pagination<ProductoDTO>
                {
                    Count = totalProductos,
                    Data = data,
                    PageCount = totalPages,
                    PageIndex = productoParams.PageIndex,
                    PageSize = productoParams.PageSize
                }
             );

        }




        //api/producto/1
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDTO>> getProducto(int id)
        {
            //spec = debe incluir la logica de la condicion de la consulta y tambien de las
            //entidades, la relacion entre el producto y marca, categoria.
            var spec = new ProductoWithCategoriaAndMarcaSpecification(id);
            var producto = await _productoRepository.GetByIdWithSpec(spec);


            if (producto == null) {
                return NotFound(new CodeErrorResponse(404, "El producto no existe."));
            }

            return _mapper.Map<Producto, ProductoDTO>(producto);

        }

        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        public async Task<ActionResult<Producto>> Post(Producto producto) {
            var resultado = await _productoRepository.Add(producto);
            if (resultado == 0) {
                throw new Exception("No se insertó el producto");
            }

            return Ok(producto);
        }


        [Authorize(Roles = "ADMIN")]
        [HttpPut("{id}")]
        public async Task<ActionResult<Producto>> Put(int id, Producto producto)
        {
            producto.Id = id;
           var resultado=  await _productoRepository.Update(producto);
            if (resultado == 0) {
                throw new Exception("No se pudo actualizar el producto");

            }
            return Ok(producto);

        }
       
            
    }
}

