﻿using System;
namespace WebApi.DTOs
{
	public class DireccionDto
	{
        public string Calle { get; set; }
        public string Ciudad { get; set; }
        public string Departamento { get; set; }
        public string CodigoPostal { get; set; }

        public string Pais { get; set; }
    }
}

