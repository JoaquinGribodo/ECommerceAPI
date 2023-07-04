using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Helper
{
    public class AppSettings
    {
        public string Key { get; set; }
        //para mapear nuestra propiedad key desde el appsettings.json hacia un objeto
    }
}
