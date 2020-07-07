using APIGraphQL.Models;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGraphQL.Types
{
    public class ChampionType : ObjectGraphType<Champion>
    {
        public ChampionType()
        {
            Field(c => c._id);
            Field(c => c.Name);
            Field(c => c.Alias);
            Field(c => c.Role);
            Field(c => c.Champion_image);
            Field(c => c.Region);
            Field(c => c.Skins);
            //Field(
            //    name: "abilites",
            //    type: typeof(AbilityType),
            //    resolve: context => 
            //);
        }
    }
}
