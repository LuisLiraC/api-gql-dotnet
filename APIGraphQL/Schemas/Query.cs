using GraphQL.Types;

namespace APIGraphQL.Schemas
{
    public class Query : ObjectGraphType
    {
        public Query()
        {
            Name = "Query";
            Field<ChampionQuery>("champion", resolve: context => new { });
        }
    }
}
