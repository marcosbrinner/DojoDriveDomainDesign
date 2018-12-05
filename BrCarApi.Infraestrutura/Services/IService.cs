using System;
using System.Linq;
using System.Linq.Expressions;

namespace BrCarApi.Infraestrutura.Servicos 
{
    public interface IService<T> where T : class
    {
        void Create(T entidade);
        void Update(T entidade);
        void Commit();
        void Delete(Func<T, bool> predicate);
      
        IQueryable<T> Read(Expression<Func<T, bool>> predicate);


        /*T Autenticar(string email, string senha);
        string GerarChaveAuditoria(int usuarioId);
        string HashMDS(string senha);
        bool VerificarEmailExiste(string email);

        T ObterPorChaveAcesso(string chaveAcesso);
        T ObterPorDataEmissao(DateTime dataHora);
        T ObterPorNumeroNota(decimal numeroNota, int empresaId);

        T ObterPorCodigoIbge(int ufCodigo);
        T ObterPorNome(string nome, int ufCodigo);

        T ObterPorCnpj(string cnpj);
        T ObterPorCpf(string cpf);
        T ObterPorNomeFantasia(string nomeFantasia);
        T ObterPorRazaoSocial(string razaoSocial);*/
    }
}