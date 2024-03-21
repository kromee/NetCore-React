using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using BusinessLogic.Data;
using Core.Entities;
using Core.Entities.OrdenCompra;
using Microsoft.Extensions.Logging;

namespace BusinessLogic.CargarData
{
	public class MarketDbContextDataXX
	{
		
		public static async Task CargarDataAsync(MarketDbContext Dbcontext, ILoggerFactory loggerFactory)
		{
			try {

                if (!Dbcontext.Marca.Any())
                {
                    var marcaData = File.ReadAllText("../BusinessLogic/CargarData/marca.json");
                    var marcas = JsonSerializer.Deserialize<List<Marca>>(marcaData);
                    foreach (var marca in marcas)
                    {
                        Dbcontext.Marca.Add(marca);
                    }
                    await Dbcontext.SaveChangesAsync();
                }

                if (!Dbcontext.Categoria.Any())
                {
                    var catData = File.ReadAllText("../BusinessLogic/CargarData/categoria.json");
                    var categorias = JsonSerializer.Deserialize<List<Categoria>>(catData);
                    foreach (var cat in categorias)
                    {
                        Dbcontext.Categoria.Add(cat);
                    }
                    await Dbcontext.SaveChangesAsync();
                }
                if (!Dbcontext.Producto.Any())
                {
                    var prodData = File.ReadAllText("../BusinessLogic/CargarData/producto.json");
                    var productos = JsonSerializer.Deserialize<List<Producto>>(prodData);
                    foreach (var prod in productos)
                    {
                        Dbcontext.Producto.Add(prod);
                    }
                    await Dbcontext.SaveChangesAsync();
                }

                if (!Dbcontext.TipoEnvios.Any())
                {
                    var tipoenvioData = File.ReadAllText("../BusinessLogic/CargarData/tipoenvio.json");
                    var tipoenvios = JsonSerializer.Deserialize<List<TipoEnvio>>(tipoenvioData);
                    foreach (var tipoenvio in tipoenvios)
                    {
                        Dbcontext.TipoEnvios.Add(tipoenvio);
                    }
                    await Dbcontext.SaveChangesAsync();
                }


            }
            catch (Exception ex) {
                var logger = loggerFactory.CreateLogger<MarketDbContextData>();
                logger.LogError(ex.Message);

            }
		}
	}
}

