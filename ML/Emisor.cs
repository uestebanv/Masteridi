using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Emisor
    {
        public int IdEmisor { get; set; }
        public string RFC {  get; set; }
        public DateTime FechaInicioOperacion { get; set; }
        public decimal Capital { get; set; }
        public List<ML.Emisor> Emisores { get; set; }
    }
}
