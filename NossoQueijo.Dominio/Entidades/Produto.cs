using System.Collections.Generic;

namespace NossoQueijo.Dominio.Entidades
{
    public class Produto
    {
        public int idProduto { get; set; }
        public string Nome { get; set; }
        public int QntdEstoque { get; set; }
        public decimal Preco { get; set; }
        public decimal Peso { get; set; }
        public IEnumerable<EstoquePorData> EstoquePorDatas { get; set; }
        public IEnumerable<PedidoProduto> PedidoProdutos { get; set; }
        public IEnumerable<FichaProducao> FichasProducao { get; set; }
    }
}