using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaPacific_Review.Models
{
    public class Cliente
    {
        public Cliente(){}

        private Cliente(int id, string nombre, string primerApellido,
            string segundoApellido, string sexo)
        {
            IdCliente = id;
            Nombres = nombre;
            PrimerApellido = primerApellido;
            SegundoApellido = segundoApellido;
            Sexo = sexo;
        }

        public int IdCliente { get; set; }
        public string Nombres { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Sexo { get; set; }
        public string FechaNacimiento { get; set; }

        public static Cliente Crear(int id, string nombre, 
            string primerApellido, string segundoApellido, string sexo)
        {
            return new Cliente( id,  nombre,  primerApellido,  segundoApellido,sexo);
        }
       
    }
}