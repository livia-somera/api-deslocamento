namespace DeslocamentoAPI.Domain.Entities
{
    public class Cliente : BaseEntity
    {

        public Cliente(string cpf, string nome)
        {
            CPF = cpf;
            Nome = nome;
        }

        private Cliente()
        {
            // utilizado pelo EF
        }

        public string CPF { get; private set; }

        public string Nome { get; private set; }

        private readonly List<Deslocamento> _deslocamentos = new();
        public IReadOnlyCollection<Deslocamento> Deslocamentos =>
            _deslocamentos.AsReadOnly();


    }
}
