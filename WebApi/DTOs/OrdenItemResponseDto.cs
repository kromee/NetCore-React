﻿using System;
namespace WebApi.DTOs
{
	public class OrdenItemResponseDto
	{
        public int ProductoId { get; set; }
        public string ProductoNombre { get; set; }
        public string ProductoImagen { get; set; }

        public decimal Precio { get; set; }

        public int Cantidad { get; set; }
    }
}

