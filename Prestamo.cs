using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyecFinal
{
  class Prestamo
{
    public decimal Monto { get; set; }
    public decimal TasaInteres { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaVencimiento { get; set; }
    public decimal SaldoPendiente { get; set; }
}

}