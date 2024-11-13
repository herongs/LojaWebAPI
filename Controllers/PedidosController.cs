using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class PedidosController : ControllerBase
{
    private readonly LojaContext _context;

    public PedidosController(LojaContext context)
    {
        _context = context;
    }

    [HttpPost("iniciar")]
    public IActionResult IniciarPedido()
    {
        var pedido = new Pedido();
        _context.Pedidos.Add(pedido);
        _context.SaveChanges();
        return Ok(pedido);
    }

    [HttpPost("{pedidoId}/adicionar")]
    public IActionResult AdicionarProduto(int pedidoId, Produto produto)
    {
        var pedido = _context.Pedidos.Find(pedidoId);
        if (pedido == null || pedido.IsFechado)
            return BadRequest("Pedido não encontrado ou já fechado.");

        pedido.Produtos.Add(produto);
        _context.SaveChanges();
        return Ok(pedido);
    }

    [HttpDelete("{pedidoId}/remover/{produtoId}")]
    public IActionResult RemoverProduto(int pedidoId, int produtoId)
    {
        // Carrega o pedido junto com seus produtos
        var pedido = _context.Pedidos
            .Include(p => p.Produtos)
            .FirstOrDefault(p => p.Id == pedidoId);

        if (pedido == null || pedido.IsFechado)
            return BadRequest("Pedido não encontrado ou já fechado.");

        // Procura pelo produto dentro do pedido
        var produto = pedido.Produtos.FirstOrDefault(p => p.Id == produtoId);

        if (produto == null)
            return NotFound("Produto não encontrado no pedido.");

        // Remove o produto da lista e salva as alterações
        pedido.Produtos.Remove(produto);
        _context.SaveChanges();
        return Ok(pedido);
    }

    [HttpPost("{pedidoId}/fechar")]
    public IActionResult FecharPedido(int pedidoId)
    {
        var pedido = _context.Pedidos.Find(pedidoId);
        if (pedido == null)
            return NotFound("Pedido não encontrado.");

            

        if (pedido.Produtos.Count == 0)
            return BadRequest("Não é possível fechar um pedido sem produtos.");

        pedido.IsFechado = true;
        _context.SaveChanges();
        return Ok(pedido);
    }

    [HttpGet]
    public IActionResult ListarPedidos(string? status = null, int page = 1, int pageSize = 10)
    {
        // Filtra por status, se fornecido
        var query = _context.Pedidos.AsQueryable();

        if (!string.IsNullOrEmpty(status))
        {
            bool isFechado = status.ToLower() == "fechado";
            query = query.Where(p => p.IsFechado == isFechado);
        }

        var totalPedidos = query.Count();
        var pedidos = query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        return Ok(new
        {
            TotalPedidos = totalPedidos,
            Page = page,
            PageSize = pageSize,
            Pedidos = pedidos
        });
    }

    [HttpGet("{id}")]
    public IActionResult ObterPedido(int id)
    {
        var pedido = _context.Pedidos.Include(p => p.Produtos).FirstOrDefault(p => p.Id == id);
        if (pedido == null)
            return NotFound();

        return Ok(pedido);
    }
}
