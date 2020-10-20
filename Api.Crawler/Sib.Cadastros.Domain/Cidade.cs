namespace Sib.Cadastros.Domain
{
    public class Cidade
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Uf { get; private set; }

        protected Cidade() { }

        public Cidade(int id, string nome, string uf)
        {
            this.Nome = nome;
            this.Uf = uf;
            this.Id = id;
        }
    }
}
