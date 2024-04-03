using GraphQL.Domain;
using GraphQL.Types;

namespace GraphQL.Infrastructure.GraphQL.TypeSystem.Input
{
    internal class PrecoInput : InputObjectGraphType<Preco>
    {
        public PrecoInput()
        {
            Field<NonNullGraphType<DecimalGraphType>>(nameof(Preco.Valor));
            Field<NonNullGraphType<DecimalGraphType>>(nameof(Preco.DescontoAVista));
        }
    }
}