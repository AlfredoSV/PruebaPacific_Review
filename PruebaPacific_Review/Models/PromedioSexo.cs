using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaPacific_Review.Models
{
    public class PromedioSexo
    {
        private PromedioSexo(string sexo, decimal promedio)
        {
            Sexo = sexo;
            Promedio = promedio;
        }

        public string Sexo { get; set; }
        public decimal Promedio { get; set; }

        public static PromedioSexo Create(string sexo, decimal promedio)
        {
            return new PromedioSexo(sexo, promedio);
        }
    }
}