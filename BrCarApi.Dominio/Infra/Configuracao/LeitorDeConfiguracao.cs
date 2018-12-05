using System;
using System.Configuration;

namespace BrCarApi.Dominio.Infraestrutura.Configuracao
{
    public class LeitorDeConfiguracao : ILeitorDeConfiguracao
    {
        public string EmailSenha()
        {
            string emailSenha = ConfigurationManager.AppSettings["EmailSenha"];

            if (!string.IsNullOrEmpty(emailSenha))
            {
                return emailSenha;
            }
            throw new Exception("Configuração \"Senha\" inválida: \"" + emailSenha + "\".");
        }

        public string EmailUsuario()
        {
            string emailUsuario = ConfigurationManager.AppSettings["EmailUsuario"];

            if (!string.IsNullOrEmpty(emailUsuario))
            {
                return emailUsuario;
            }
            throw new Exception("Configuração \"E-mail\" inválida: \"" + emailUsuario + "\".");
        }

        public int SmtpPorta()
        {
            var smtpPorta = ConfigurationManager.AppSettings["SmtpPorta"];

            if (!string.IsNullOrEmpty(smtpPorta))
            {
                return Convert.ToInt32(smtpPorta);
            }
            throw new Exception("Configuração \"Porta SMTP\" inválida: \"" + smtpPorta + "\".");
        }

        public string SmtpServidor()
        {
            var smtpServidor = ConfigurationManager.AppSettings["SmtpServidor"];
            if (!string.IsNullOrEmpty(smtpServidor))
            {
                return smtpServidor;
            }
            throw new Exception("Configuração \"Servidor SMTP\" inválida: \"" + smtpServidor + "\".");
        }

        public string UrlSistema()
        {
            var urlSistema = ConfigurationManager.AppSettings["UrlSistema"];
            if (!string.IsNullOrEmpty(urlSistema))
            {
                return urlSistema;
            }
            throw new Exception("Configuração \"URL do Sistema\" inválida: \"" + urlSistema + "\".");
        }

        public string EmpresaNome()
        {
            var configuracao = ConfigurationManager.AppSettings["EmpresaNome"];
            if (!string.IsNullOrEmpty(configuracao))
            {
                return configuracao;
            }
            throw new Exception("Configuração \"Nome da empresa\" inválida: \"" + configuracao + "\".");
        }

        public string EmpresaTelefone()
        {
            var configuracao = ConfigurationManager.AppSettings["EmpresaTelefone"];
            if (!string.IsNullOrEmpty(configuracao))
            {
                return configuracao;
            }
            throw new Exception("Configuração \"Telefone\" inválida: \"" + configuracao + "\".");
        }

        public string EmpresaEmail()
        {
            var configuracao = ConfigurationManager.AppSettings["EmpresaEmail"];
            if (!string.IsNullOrEmpty(configuracao))
            {
                return configuracao;
            }
            throw new Exception("Configuração \"E-mail\" inválida: \"" + configuracao + "\".");
        }

        public string EmpresaEstado()
        {
            var configuracao = ConfigurationManager.AppSettings["EmpresaEstado"];
            if (!string.IsNullOrEmpty(configuracao))
            {
                return configuracao;
            }
            throw new Exception("Configuração \"Estado/UF\" inválida: \"" + configuracao + "\".");
        }

        public string EmpresaLogradouro()
        {
            var configuracao = ConfigurationManager.AppSettings["EmpresaLogradouro"];
            if (!string.IsNullOrEmpty(configuracao))
            {
                return configuracao;
            }
            throw new Exception("Configuração \"Endereço\" inválida: \"" + configuracao + "\".");
        }

        public string EmpresaCep()
        {
            var configuracao = ConfigurationManager.AppSettings["EmpresaCep"];
            if (!string.IsNullOrEmpty(configuracao))
            {
                return configuracao;
            }
            throw new Exception("Configuração \"CEP\" inválida: \"" + configuracao + "\".");
        }
    }
}