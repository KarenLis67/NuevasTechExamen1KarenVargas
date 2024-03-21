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
    public class ProveedorRepositorio : IProveedorRepositorio
    {
        private readonly string? cadenaConexion;
        private readonly string tablaNombre;
        private readonly IConfiguration configuration;
        public ProveedorRepositorio(IConfiguration conf)
        {
            configuration = conf;
            cadenaConexion = configuration.GetSection("cadenaconexion").Value;
            tablaNombre = "Proveedor";
        }
        public async Task<bool> Create(Proveedor proveedor)
        {
            try
            {
                var tablaCliente = new TableClient(cadenaConexion, tablaNombre);
                await tablaCliente.UpsertEntityAsync(proveedor);
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

        public async Task<Proveedor> Get(string id)
        {
            var tablaCliente = new TableClient(cadenaConexion, tablaNombre);
            var filtro = $"PartitionKey eq 'Proveedor' and RowKey eq '{id}'";
            await foreach (Proveedor proveedor in tablaCliente.QueryAsync<Proveedor>(filter: filtro))
            {
                return proveedor;
            }
            return null;
        }

        public async Task<List<Proveedor>> GetAll()
        {
            List<Proveedor> lista = new List<Proveedor>();
            var tablaCliente = new TableClient(cadenaConexion, tablaNombre);
            var filtro = $"PartitionKey eq 'Proveedor'";
            await foreach (Proveedor proveedor in tablaCliente.QueryAsync<Proveedor>(filter: filtro))
            {
                lista.Add(proveedor);
            }

            return lista;
        }

        public async Task<bool> Update(Proveedor proveedor)
        {
            try
            {
                var tablaCliente = new TableClient(cadenaConexion, tablaNombre);
                await tablaCliente.UpdateEntityAsync(proveedor, proveedor.ETag);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

}
