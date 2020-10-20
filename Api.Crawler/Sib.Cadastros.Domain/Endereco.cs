namespace Sib.Cadastros.Domain
{
    public class Endereco
    {
        public int Id { get; private set; }
        public string Cep { get; private set; }
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public Cidade Cidade { get; private set; }

        protected Endereco() { }

        public Endereco(int id, string cep, string logradouro, string numero, string complemento, string bairro, Cidade cidade)
        {
            this.Cep = cep;
            this.Logradouro = logradouro;
            this.Numero = numero;
            this.Complemento = complemento;
            this.Bairro = bairro;
            this.Cidade = cidade;
            this.Id = id;
        }

    }
}
