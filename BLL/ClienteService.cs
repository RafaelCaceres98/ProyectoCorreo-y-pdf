using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;
using Infraestructura;


namespace BLL
{
   public class ClienteService
    {
        
        private ClienteRepository clienteRepository;
        private readonly ConnectionManager connection;

        public ClienteService(string connectionString)
        {
            connection = new ConnectionManager(connectionString);
            clienteRepository = new ClienteRepository(connection);
        }

        public string GuardarCliente(Cliente cliente)
        {
            Correo correo = new Correo();
            string MensajeEmail = string.Empty;
            try
            {

                connection.Open();
                clienteRepository.Guardar(cliente);
                MensajeEmail = correo.EnviarEmail(cliente);
                return $"Se ah guardado correctamente" + MensajeEmail;
            }
            catch (Exception e)
            {

                return $"Ah ocurrido un problema{e.Message.ToString()}";
            }
            finally { connection.Close(); }
        }
            public string GenerarPdf(List<Cliente> clientes, string filename)
            {
                DocumentoPdf documentoPdf = new DocumentoPdf();
                try
                {
                    documentoPdf.GuardarPdf(clientes, filename);
                    return "Se generó el Documento satisfactoriamente";
                }
                catch (Exception e)
                {

                    return "Error al crear docuemnto" + e.Message;
                }
            }

        }
    }

