using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrCarApi.Dominio.Entidades.Clientes
{
    public class Clientes
    {
        public int ClienteID { get; set; }
        public string CliNome { get; set; }
        public string CliEmail { get; set; }
        public string CliSenha { get; set; }
        public long CliCPF { get; set; }
        public long CliTelefone { get; set; }
    }
}