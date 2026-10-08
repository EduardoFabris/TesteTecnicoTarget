using DesafioTecnico.API.Models;
using DesafioTecnico.API.DTOs;

namespace DesafioTecnico.API.Services;

public class EstoqueService
{
    private readonly List<Produto> _produtos = new()
    {
        new Produto
        {
            CodigoProduto = 101,
            DescricaoProduto = "Caneta Azul",
            Estoque = 150
        },
        new Produto
        {
            CodigoProduto = 102,
            DescricaoProduto = "Caderno Universitário",
            Estoque = 75
        },
        new Produto
        {
            CodigoProduto = 103,
            DescricaoProduto = "Borracha Branca",
            Estoque = 200
        },
        new Produto
        {
            CodigoProduto = 104,
            DescricaoProduto = "Lápis Preto HB",
            Estoque = 320
        },
        new Produto
        {
            CodigoProduto = 105,
            DescricaoProduto = "Marcador de Texto Amarelo",
            Estoque = 90
        }
    };

    private readonly List<MovimentacaoEstoque> _movimentacoes = new();

    private int _proximoId = 1;

    public Produto? BuscarProduto(int codigoProduto)
    {
        return _produtos.FirstOrDefault(p => p.CodigoProduto == codigoProduto);
    }

    public MovimentacaoEstoque MovimentarEstoque(MovimentacaoEstoqueDTO movimentacao)
    {
        var produto = BuscarProduto(movimentacao.CodigoProduto);

        if (produto == null)
        {
            throw new Exception("Produto não encontrado.");
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
            Id = _proximoId++,
            CodigoProduto = movimentacao.CodigoProduto,
            DescricaoProduto = produto.DescricaoProduto,
            TipoMovimentacao = movimentacao.TipoMovimentacao,
            Descricao = movimentacao.Descricao,
            Quantidade = movimentacao.Quantidade,
            EstoqueAtual = produto.Estoque
        };

        _movimentacoes.Add(novaMovimentacao);

        return novaMovimentacao;
    }
}