﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public decimal PrecioUnitario { get; set; }
    }
}
