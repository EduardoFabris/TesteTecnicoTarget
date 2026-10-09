using DesafioTecnico.API.Models;
using DesafioTecnico.API.Data;
using DesafioTecnico.API.DTOs;

namespace DesafioTecnico.API.Services;

public class EstoqueService
{
    private readonly EstoqueDbContext _context;

    public EstoqueService(EstoqueDbContext context)
    {
        _context = context;
    }

    public Produto? BuscarProduto(int codigoProduto)
    {
        return _context.Produtos
            .FirstOrDefault(p => p.CodigoProduto == codigoProduto);
    }

    
    public MovimentacaoEstoque MovimentarEstoque(MovimentacaoEstoqueDTO movimentacao)
    {
        var produto = BuscarProduto(movimentacao.CodigoProduto);

        if (produto == null)
        {
            throw new Exception("Produto não encontrado.");
        }

        if (movimentacao.Quantidade <= 0)
        {
            throw new Exception("A quantidade deve ser maior que zero.");
        }

        if (movimentacao.TipoMovimentacao.Equals("Entrada", StringComparison.OrdinalIgnoreCase))
        {
            produto.Estoque += movimentacao.Quantidade;
        }
        else if (movimentacao.TipoMovimentacao.Equals("Saida", StringComparison.OrdinalIgnoreCase))
        {
            if (movimentacao.Quantidade > produto.Estoque)
            {
                throw new Exception("Estoque insuficiente para realizar a saída.");
            }

            produto.Estoque -= movimentacao.Quantidade;
        }
        else
        {
            throw new Exception("Tipo de movimentação inválido.");
        }

        var novaMovimentacao = new MovimentacaoEstoque
        {
            CodigoProduto = movimentacao.CodigoProduto,
            DescricaoProduto = produto.DescricaoProduto,
            TipoMovimentacao = movimentacao.TipoMovimentacao,
            Descricao = movimentacao.Descricao,
            Quantidade = movimentacao.Quantidade,
            EstoqueAtual = produto.Estoque
        };

        _context.MovimentacoesEstoque.Add(novaMovimentacao);

        _context.SaveChanges();

        return novaMovimentacao;
    }
}