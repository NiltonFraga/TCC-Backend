
namespace Api.Domain
{
    public class Usuario : Entity
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Foto { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public string Senha { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
