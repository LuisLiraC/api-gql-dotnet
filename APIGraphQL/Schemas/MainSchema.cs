using GraphQL;
using GraphQL.Types;

namespace APIGraphQL.Schemas
{
    public class MainSchema : Schema
    {
        public MainSchema(IDependencyResolver resolver): base (resolver)
        {
            Query = new Query();
        }
    }
}
