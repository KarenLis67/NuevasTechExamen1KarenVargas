using Azure;
using Azure.Data.Tables;
using NuevasTech.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevasTech.API.Modelos
{
    public class Proveedor: IProveedor,ITableEntity

    {

        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string PartitionKey { get ; set ; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
    }
}
