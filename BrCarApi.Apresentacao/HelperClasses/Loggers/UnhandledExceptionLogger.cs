using BrCarApi.Dominio.Utilitarios;
using System;
using System.Data.Entity.Validation;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Http.ExceptionHandling;

namespace BrCarApi.Apresentacao.HelperClasses.Loggers
{
    public class UnhandledExceptionLogger : ExceptionLogger
    {        
        public override void Log(ExceptionLoggerContext context)
        {
            var log = context.Exception.ToString();
            var path = ObterNomeArquivo();

            using (var tw = new StreamWriter(path, true, Encoding.UTF8))
            {
                if (context.Exception is DbEntityValidationException)
                {
                    var dbEntityException = (DbEntityValidationException)context.Exception;

                    foreach (var item in dbEntityException.EntityValidationErrors)
                    {
                        log = string.Format("Entidade do tipo \"{0}\" no estado \"{1}\" tem os seguintes erros de validação:",
                            item.Entry.Entity.GetType().Name, item.Entry.State);

                        foreach (var erro in item.ValidationErrors)
                        {
                            log += string.Format("- Property: \"{0}\", Erro: \"{1}\"", erro.PropertyName, erro.ErrorMessage);
                        }
                    }
                }

                tw.WriteLine(log);
                tw.Close();
            }
        }

        private string ObterNomeArquivo()
        {
            //var filePath = "e:/wwwroot/wwwArquivarNFe/Log";
            var filePath = HttpContext.Current.Server.MapPath("~/Log");
            var ext = "txt";
            var name = TimeSpan.FromTicks(DateTime.Now.Ticks).ToString().SomenteDigitos();
            var file = string.Format("{0}\\{1}.{2}", filePath, name, ext);

            if (File.Exists(file))
            {
                file = ObterNomeArquivo();
            }
            return file;
        }

        /*public override void Log(ExceptionLoggerContext context)
        {
            File.AppendAllText(filePath, context.Exception.ToString());
        }*/
    }
}