﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.ViewModel
{
    public class ProductViewModel
    {
        public string Descripcion { get; set; } = string.Empty;
        public decimal? SubTotal { get; set; }
        public decimal? PrecioUnitario { get; set; }

    }
}
