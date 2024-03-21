﻿using System;
using AutoMapper;
using Core.Entities;
using Core.Entities.OrdenCompra;

namespace WebApi.DTOs
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Producto, ProductoDTO>()
                .ForMember(p => p.CategoriaNombre, x => x.MapFrom(a => a.Categoria.Nombre))
                .ForMember(p => p.MarcaNombre, x => x.MapFrom(a => a.Marca.Nombre));

            CreateMap<Core.Entities.Direccion, DireccionDto>().ReverseMap();
            CreateMap<Usuario, UsuarioDto>().ReverseMap();

            CreateMap<DireccionDto, Core.Entities.OrdenCompra.Direccion>();
            CreateMap<OrdenCompras, OrdenCompraResponseDto>()
                .ForMember(o => o.TipoEnvio, x => x.MapFrom(y => y.TipoEnvio.Nombre))
                .ForMember(o => o.TipoEnvioPrecio, x => x.MapFrom(y => y.TipoEnvio.Precio));

            CreateMap<OrdenItem, OrdenItemResponseDto>()
                .ForMember(o => o.ProductoId, x => x.MapFrom(y => y.ItemOrdenado.ProductoItemId))
                .ForMember(o => o.ProductoNombre, x => x.MapFrom(y => y.ItemOrdenado.ProductoNombre))
                .ForMember(o => o.ProductoImagen, x => x.MapFrom(y => y.ItemOrdenado.ImagenUrl));

        }
    }
}

