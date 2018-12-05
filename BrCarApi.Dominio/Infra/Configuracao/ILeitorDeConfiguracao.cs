using System;

namespace BrCarApi.Dominio.Infraestrutura.Configuracao
{
    public interface ILeitorDeConfiguracao
    {
        String EmailUsuario();
        String EmailSenha();
        String SmtpServidor();
        Int32 SmtpPorta();
        String UrlSistema();

        String EmpresaNome();
        String EmpresaTelefone();
        String EmpresaEmail();
        String EmpresaEstado();
        String EmpresaLogradouro();
        String EmpresaCep();
    }
}
