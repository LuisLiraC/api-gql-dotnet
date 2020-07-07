using APIGraphQL.Models;
using APIGraphQL.Services;
using APIGraphQL.Types;
using GraphQL.Types;

namespace APIGraphQL.Schemas
{
    public class ChampionQuery : ObjectGraphType
    {
        public ChampionQuery(IChampionService service)
        {
            FieldAsync<ChampionType, Champion>(
                "getChampion",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> { Name = "name" }
                ),
                resolve: context =>
                {
                    var name = context.GetArgument<string>("name");
                    return service.GetAsync(name);
                }
            );
        }
    }
}
