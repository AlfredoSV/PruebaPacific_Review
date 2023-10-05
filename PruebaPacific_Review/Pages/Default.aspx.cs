using PruebaPacific_Review.Models;
using PruebaPacific_Review.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using System.Drawing;

namespace PruebaPacific_Review.Pages
{
    public partial class Default : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack && DateForm.Text == string.Empty)
            {
                DateForm.Text = $"El sistema se corrio por primera vez a las {DateTime.Now.Date}";
                Session["clientes"] = null;
            }
            else            
                LoadValues();
            
        }

        protected void CambioValorDrop_SelectedIndexChanged(object sender, EventArgs e)
        {
            ServicioCliente servicioCliente = new ServicioCliente();
            DropDownList ddl = (DropDownList)sender;
            int clienteId = int.Parse(ddl.ID);
            string nuevoSexo = ddl.SelectedValue;

            Session["clientes"] = servicioCliente.UpdateClienteSexo((List<Cliente>)Session["clientes"], clienteId, nuevoSexo);
            Cliente cli = servicioCliente.GetClientePorId(clienteId);
            List<PromedioSexo> prom = servicioCliente.GetPromSexo((List<Cliente>)Session["clientes"]).ToList();

            TableRow fila = new TableRow();
            TableCell primera = new TableCell();
            primera.Text = "Registro Modificado";
            fila.Cells.Add(primera);
            TableCell segunda = new TableCell();
            segunda.Text = $"{cli.PrimerApellido} {cli.SegundoApellido} {cli.Nombres}({nuevoSexo})";
            fila.Cells.Add(segunda);
            TableCell tercera = new TableCell();
            tercera.Text = string.Empty;
            fila.Cells.Add(tercera);
            TableCell cuarta = new TableCell();
            cuarta.Text = $"M:{Math.Round(prom.Where(p => p.Sexo.Equals("M")).FirstOrDefault().Promedio,4)}% " +
                $"F:{ Math.Round(prom.Where(p => p.Sexo.Equals("F")).FirstOrDefault().Promedio,4)}%";
            fila.Cells.Add(cuarta);

            fila.ForeColor = nuevoSexo.Equals("F") ? Color.Black :Color.White;
            fila.BackColor = nuevoSexo.Equals("F") ? Color.Pink : Color.Blue;

            tblClientes.Rows.Add(fila);

        }


        protected void CargaTabla_Click(object sender, EventArgs e) => LoadValues();

        public void LoadValues()
        {

            ServicioCliente servicioCliente = new ServicioCliente();
            List<Cliente> clientes;

            if (Session["clientes"] is null)
            {
                clientes = servicioCliente.GetClientes().ToList();
                Session["clientes"] = clientes;
            }
            else
            {
                clientes = (List<Cliente>)
                    Session["clientes"];
            }

            foreach (Cliente cliente in clientes)
            {
                TableRow fila = new TableRow();
                TableCell primerApellido = new TableCell();
                primerApellido.Text = cliente.PrimerApellido;
                fila.Cells.Add(primerApellido);
                TableCell segundoApellido = new TableCell();
                segundoApellido.Text = cliente.SegundoApellido;
                fila.Cells.Add(segundoApellido);
                TableCell nombre = new TableCell();
                nombre.Text = cliente.Nombres;
                fila.Cells.Add(nombre);
                TableRow drop = new TableRow();
                TableCell sexo = new TableCell();
                DropDownList dropDownList = new DropDownList();
                dropDownList.AutoPostBack = true;
                dropDownList.ID = cliente.IdCliente.ToString();
                dropDownList.SelectedIndexChanged += new EventHandler(CambioValorDrop_SelectedIndexChanged);
                dropDownList.Items.Add(new ListItem("Masculino", "M"));
                dropDownList.Items.Add(new ListItem("Femenino", "F"));
                dropDownList.SelectedValue = cliente.Sexo;
                sexo.Controls.Add(dropDownList);
                drop.Cells.Add(sexo);
                fila.Cells.Add(sexo);

                tblClientes.Rows.Add(fila);
            }

            tblClientes.Visible = true;
            CargaTabla.Visible = false;
        }


    }
}