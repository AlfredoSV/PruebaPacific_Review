using Newtonsoft.Json;
using PruebaPacific_Review.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;


namespace PruebaPacific_Review.Servicios
{
    public class ServicioCliente
    {
        public IEnumerable<Cliente> GetClientes()
        {
            List<Cliente> result = new List<Cliente>();
            using (HttpClient httpClient = new HttpClient())
            {

                string urlServicio = "https://pos.dermalia.mx/webforms/data";
                try
                {
                    HttpResponseMessage response = httpClient.GetAsync(urlServicio).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string contenido = response.Content.ReadAsStringAsync().Result;

                        result = JsonConvert.DeserializeObject<List<Cliente>>(contenido);
                    }

                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return result;
        }

        public Cliente GetClientePorId(int id) => GetClientes().Where( c => c.IdCliente ==id).FirstOrDefault();

        public IEnumerable<PromedioSexo> GetPromSexo(List<Cliente> clientesP)
        {
            List<Cliente> clientes = clientesP;

            List<PromedioSexo> promedioSexos = new List<PromedioSexo>();

            decimal promF = (decimal)(clientes.Count(p => p.Sexo.Equals("F")) * 100) / clientes.Count();
            decimal promM = (decimal)(clientes.Count(p => p.Sexo.Equals("M")) * 100) / clientes.Count();

            promedioSexos.Add(PromedioSexo.Create("F", promF));

            promedioSexos.Add(PromedioSexo.Create("M", promM));

            return promedioSexos;

        }

        public IEnumerable<Cliente> UpdateClienteSexo(List<Cliente> clientesP, int id, string nuevoSexo)
        {
            clientesP.Where(c => c.IdCliente == id).FirstOrDefault().Sexo = nuevoSexo;

            return clientesP;
        }

    }
}