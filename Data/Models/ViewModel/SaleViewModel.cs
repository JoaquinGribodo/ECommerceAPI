using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.ViewModel
{
    public class SaleViewModel
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public int IdUsuario { get; set; }
        public DateTime? FechaVenta { get; set; }
        public decimal? MontoTotal { get; set; }
    }
}
