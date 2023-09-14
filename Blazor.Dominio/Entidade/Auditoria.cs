
using Blazor.Dominio.Modelo;
using Blazor.Dominio.Util;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blazor.Dominio.Entidade
{
    public class Auditoria //: IEntidade // : PersistenciaDados
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid Id_Tenant { get; set; }
        public virtual Tenant TenantAuditoria { get; set; }

        ////public Guid Id_Usuario { get; set; }
        ////public Guid IdentificadorRegistro { get; set; }


        //[Required(ErrorMessage = "É obrigatório informar o NomeTabela!")]
        //[MaxLength(50)]
        public string NomeTabela { get; set; }  

        //[Required(ErrorMessage = "É obrigatório informar o ModoCrud!")]
        //[MaxLength(15)]
        public string ModoCrud { get; set; }  
        
        //[Required(ErrorMessage = "É obrigatório informar a DataAtual!")]
        public DateTime DataCadastro { get; set; } 
        
        //[Required(ErrorMessage = "É obrigatório informar o HistoricoAntes!")]
        //[MaxLength(500)]
        public string HistoricoAntes { get; set; }  
        
        //[Required(ErrorMessage = "É obrigatório informar o HistoricoDepois!")]
        //[MaxLength(500)]
        public string HistoricoDepois { get; set; } 

        public Auditoria DadosDoIncluir(Guid idtenant, Guid? idRegistroAtual, string nomeTabela)
        {
 
            
            Id_Tenant = idtenant;
            //Id_Usuario = usuario;
            //  Id_Registro = idRegistroAtual;
            NomeTabela = nomeTabela;
            ModoCrud = ModoCruds.Inserir.GetDescricao();
            DataCadastro = DateTime.Now;
            HistoricoAntes = "Não tem";
            HistoricoDepois = "Exemplo";


            return this;
        }

        public Auditoria DadosDoAlterar(Guid idtenant, Guid? idRegistroAtual, string nomeTabela)
        {
            Id_Tenant = idtenant;
            //Id_Usuario = usuario;
            //  Id_Registro = idRegistroAtual;
            NomeTabela = nomeTabela;
            ModoCrud = ModoCruds.Alterar.GetDescricao();
            DataCadastro = DateTime.Now;
            HistoricoAntes = "Não tem";
            HistoricoDepois = "Exemplo";


            return this;
        }


        public Auditoria DadosDoExcluir(Guid idtenant, Guid? idRegistroAtual, string nomeTabela)
        {
            Id_Tenant = idtenant;
            //Id_Usuario = usuario;
            //  Id_Registro = idRegistroAtual;
            NomeTabela = nomeTabela;
            ModoCrud = ModoCruds.Excluir.GetDescricao();
            DataCadastro = DateTime.Now;
            HistoricoAntes = "Não tem";
            HistoricoDepois = "Exemplo";


            return this;
        }

    }


}
