public class Pedido
{
    public int Id { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.Now;
    public bool IsFechado { get; set; } = false;
    public List<Produto> Produtos { get; set; } = new List<Produto>();
}
