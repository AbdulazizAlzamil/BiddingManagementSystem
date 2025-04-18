using MediatR;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace BiddingManagementSystem.Application.Features.Bids.Commands.ScoreBid
{
    /// <summary>
    /// Command to score a bid with evaluation criteria and comments.
    /// </summary>
    public class ScoreBidCommand : IRequest<bool>
    {
        public int TenderId { get; set; }
        public int BidId { get; set; }
        public string Comments { get; set; }

        /// <summary>
        /// Dictionary where keys represent evaluation criteria IDs (1 to 5) and values represent evaluation scores.
        /// </summary>
        public IDictionary<int, int> Scores { get; set; }
    }

    /// <summary>
    /// Custom schema filter to modify the Swagger example for ScoreBidCommand.
    /// </summary>
    public class ScoreBidCommandSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if(context.Type == typeof(ScoreBidCommand))
            {
                schema.Properties["scores"].Example = new OpenApiObject
                {
                    ["1"] = new OpenApiInteger(0),
                    ["2"] = new OpenApiInteger(0),
                    ["3"] = new OpenApiInteger(0),
                    ["4"] = new OpenApiInteger(0),
                    ["5"] = new OpenApiInteger(0)
                };
            }
        }
    }
}

