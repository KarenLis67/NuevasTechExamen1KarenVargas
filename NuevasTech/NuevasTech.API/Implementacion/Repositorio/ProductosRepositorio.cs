using Azure.Data.Tables;
using Microsoft.Extensions.Configuration;
using NuevasTech.API.Contratos.Repositorio;
using NuevasTech.API.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevasTech.API.Implementacion.Repositorio
{
    public class ProductosRepositorio : IProductosRepositorio
    {
        private readonly string? cadenaConexion;
        private readonly string tablaNombre;
        private readonly IConfiguration configuration;
        public ProductosRepositorio(IConfiguration conf)
        {
            configuration = conf;
            cadenaConexion = configuration.GetSection("cadenaconexion").Value;
            tablaNombre = "Productos";
        }
        public async Task<bool> Create(Productos producto)
        {
            try
            {
                var tablaCliente = new TableClient(cadenaConexion, tablaNombre);
                await tablaCliente.UpsertEntityAsync(producto);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> Delete(string partitionKey, string rowkey, string etag)
        {
            try
            {
                var tablaCliente = new TableClient(cadenaConexion, tablaNombre);
                await tablaCliente.DeleteEntityAsync(partitionKey, rowkey);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Task<bool> Delete(string partitionKey, string rowkey)
        {
            throw new NotImplementedException();
        }

        public async Task<Productos> Get(string id)
        {
            var tablaCliente = new TableClient(cadenaConexion, tablaNombre);
            var filtro = $"PartitionKey eq 'Productos' and RowKey eq '{id}'";
            await foreach (Productos producto in tablaCliente.QueryAsync<Productos>(filter: filtro))
            {
                return producto;
            }
            return null;
        }

        public async Task<List<Productos>> GetAll()
        {
            List<Productos> lista = new List<Productos>();
            var tablaCliente = new TableClient(cadenaConexion, tablaNombre);
            var filtro = $"PartitionKey eq 'Productos'";
            await foreach (Productos producto in tablaCliente.QueryAsync<Productos>(filter: filtro))
            {
                lista.Add(producto);
            }

            return lista;
        }

        public async Task<bool> Update(Productos producto)
        {
            try
            {
                var tablaCliente = new TableClient(cadenaConexion, tablaNombre);
                await tablaCliente.UpdateEntityAsync(producto, producto.ETag);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

}
