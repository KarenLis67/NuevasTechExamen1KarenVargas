using NuevasTech.API.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevasTech.API.Contratos.Repositorio
{
    public interface IProveedorRepositorio
    {
        Task<bool> Create(Proveedor proveedor);
        Task<bool> Update(Proveedor proveedor);
        Task<bool> Delete(string partitionKey, string rowkey);
        Task<List<Proveedor>> GetAll();
        Task<Proveedor> Get(string id);
    }

}
