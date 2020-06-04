using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Entity;
using System.Net.Mail;

namespace Interfaz
{
    public partial class FormAgregarCliente : Form
    {

        Cliente cliente;
        List<Cliente> clientes;
        ClienteService clienteService = new ClienteService(ConfigConnection.connectionString);

        public FormAgregarCliente()
        {
            InitializeComponent();
            clientes = new List<Cliente>();
        }

        public string GuardarDato()
        {

            cliente = new Cliente();
            cliente.Cedula = cedulaTxt.Text;
            cliente.PrimerNombre = primerNombreTxt.Text;
            cliente.SegundoNombre = segundoNombreTxt.Text;
            cliente.PrimerApellido = primerApellidoTxt.Text;
            cliente.SegundoApellido = segundoApellidoTxt.Text;
            cliente.Genero = sexoBox.SelectedItem.ToString();
            cliente.Celular = cedulaTxt.Text;
            cliente.Direccion = direccionTxt.Text;
            cliente.Email = new MailAddress(txtCorreo.Text);

            return clienteService.GuardarCliente(cliente);

        }

        private void FormAgregarCliente_Load(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(GuardarDato(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnPdf_Click(object sender, EventArgs e)
        {

            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "Guardar Informe";
                saveFileDialog.InitialDirectory = @"c:/Documentos";
                saveFileDialog.DefaultExt = "pdf";
                string filename = "";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filename = saveFileDialog.FileName;
                    if (filename != "" && clientes.Count > 0)
                    {
                        string mensaje = clienteService.GenerarPdf(clientes, filename);

                        MessageBox.Show(mensaje, "Generar Pdf", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("No se especifico una ruta o No hay datos para generar el reporte", "Generar Pdf", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
        }
    }
}
        

