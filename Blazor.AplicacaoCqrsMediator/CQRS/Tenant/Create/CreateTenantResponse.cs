namespace Blazor.AplicacaoCqrsMediator.CQRS.Tenant.Create
{
    public class CreateTenantResponse
    {
        public Guid Id { get; set; }
        public Guid? Id_Imagem { get; set; }
        public string Referencia { get; set; }  
        public string Descricao { get; set; } 
        public bool Inativo { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
    }
}
