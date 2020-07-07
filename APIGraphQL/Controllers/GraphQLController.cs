using APIGraphQL.Schemas;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using GraphQL;

namespace APIGraphQL.Controllers
{
    public class GraphQLQuery
    {
        public string OperationName { get; set; }
        public string Query { get; set; }
        public JObject Variables { get; set; }
    }
    [ApiController]
    [Route("[controller]")]
    public class GraphQLController : ControllerBase
    {
        private MainSchema _schema;

        public GraphQLController(MainSchema schema)
        {
            _schema = schema;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] GraphQLQuery query)
        {
            var json = await _schema.ExecuteAsync(_ =>
            {
                _.Query = query.Query;
                _.Inputs = query.Variables.ToInputs();
            });
            var response = new JsonResult(JsonConvert.DeserializeObject(json));
            return response;
        }

    }
}
