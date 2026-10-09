using Microsoft.EntityFrameworkCore;
using DesafioTecnico.API.Models;

namespace DesafioTecnico.API.Data;

public class EstoqueDbContext : DbContext
{
    public EstoqueDbContext(DbContextOptions<EstoqueDbContext> options)
        : base(options)
    {
    }

    public DbSet<Produto> Produtos => Set<Produto>();

    public DbSet<MovimentacaoEstoque> MovimentacoesEstoque
        => Set<MovimentacaoEstoque>();

    //Configuração para o EF reconhecer CodigoProduto como chave primária no banco
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Produto>()
            .HasKey(p => p.CodigoProduto);

        //Adicionando os primeiros produtos que foram enviados no JSON do desafio
        modelBuilder.Entity<Produto>().HasData(
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
        );
    }
}