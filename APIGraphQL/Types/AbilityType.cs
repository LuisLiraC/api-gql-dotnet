using APIGraphQL.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGraphQL.Types
{
    public class AbilityType : ObjectGraphType<Ability>
    {
        public AbilityType()
        {
            Field(a => a.Type);
            Field(a => a.Name);
            Field(a => a.Description);
            Field(a => a.Image);
        }
    }
}
