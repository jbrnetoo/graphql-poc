using GraphQL.Infrastructure.Repository;

namespace GraphQL.Infrastructure.GraphQL
{
    public class ProdutosSchema : Types.Schema
    {
        public ProdutosSchema(ProdutoRepository produtoRepository, IServiceProvider services) : base(services)
        {
            Query = new ProdutosQuery(produtoRepository);
            Mutation = new ProdutosMutation(produtoRepository);
        }
    }
}
