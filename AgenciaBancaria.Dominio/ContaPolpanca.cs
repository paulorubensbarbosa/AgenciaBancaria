using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaBancaria.Dominio
{
    public class ContaPolpanca : ContaBancaria
    {
        public ContaPolpanca(Cliente cliente) : base (cliente)
        {
            //0,30%
            PercentualRendimento = 0.003M;
        }

        public decimal PercentualRendimento { get; private set; }
    }
}
