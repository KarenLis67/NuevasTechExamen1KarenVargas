using NuevasTech.API.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevasTech.API.Contratos.Repositorio
{
    public interface IProductosRepositorio
    {
        Task<bool> Create(Productos productos);
        Task<bool> Update(Productos productos);
        Task<bool> Delete(string partitionKey, string rowkey);
        Task<List<Productos>> GetAll();
        Task<Productos> Get(string id);
    }

}
