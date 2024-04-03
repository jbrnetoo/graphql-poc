using GraphQL.Infrastructure.GraphQL.TypeSystem.Types;
using GraphQL.Infrastructure.Repository;
using GraphQL.Types;

namespace GraphQL.Infrastructure.GraphQL
{
    public class ProdutosQuery : ObjectGraphType
    {
        public ProdutosQuery(ProdutoRepository produtoRepository) 
        {
            Field<ProdutoType>("produto",
                arguments:
                new QueryArguments(
                    new QueryArgument<StringGraphType> { Name = "codigo", Description = "Código do produto" },
                    new QueryArgument<StringGraphType> { Name = "nome", Description = "Nome do produto" }
                ),
             resolve: context =>
             {
                 string nome = context.GetArgument<string>("nome");
                 string codigo = context.GetArgument<string>("codigo");

                 var resultado = produtoRepository.ObterProduto(codigo, nome);

                 return resultado;
             },
             description: "Query para obter produto por nome ou código");
        }
    }
}
