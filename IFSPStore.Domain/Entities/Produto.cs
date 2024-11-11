using IFSPStore.Domain.Base;

namespace IFSPStore.Domain.Entities
{
    public class Produto : BaseEntity<int>
    {
        public Produto()
        {

        }

        public Produto(int id, string nome, float preco, int quantidade, DateTime dataCompra, string unidadeVenda, Grupo? grupo)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            Quantidade = quantidade;
            DataCompra = dataCompra;
            UnidadeVenda = unidadeVenda;
            Grupo = grupo;
        }

        //public int? Id { get; set; } n precisa declarar pq vem da entidade básica
        public string? Nome { get; set; }
        public float? Preco { get; set; }
        public int? Quantidade { get; set; }
        public DateTime? DataCompra { get; set; }
        public string? UnidadeVenda { get; set; }
        public Grupo? Grupo { get; set; }
    }
}
