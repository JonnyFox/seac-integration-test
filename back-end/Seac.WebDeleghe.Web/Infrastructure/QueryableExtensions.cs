using System;
using System.Linq;
using System.Threading.Tasks;
using Seac.WebDeleghe.Web.Configuration;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.UriParser;
using ODataPath = Microsoft.AspNet.OData.Routing.ODataPath;

namespace Seac.WebDeleghe.Web.Infrastructure
{
    internal static class QueryableExtensions
    {
        public static async Task<PageResult<TResult>> ToPagedResultAsync<TResult>(this IQueryable<TResult> source, HttpContext context, bool computeCount)
        {
            if (!ODataConfigurator.EntitySetNames.ContainsKey(typeof(TResult)))
            {
                throw new NotSupportedException($"A {typeof(ODataMappingConfigurator<>).FullName} is missing for type {typeof(TResult).FullName}");
            }

            var entitySetName = ODataConfigurator.EntitySetNames[typeof(TResult)];
            var entitySet = ODataConfigurator.EdmModel.EntityContainer.FindEntitySet(entitySetName);

            var queryContext = new ODataQueryContext(ODataConfigurator.EdmModel, typeof(TResult), new ODataPath(new EntitySetSegment(entitySet)));
            var queryOptions = new ODataQueryOptions<TResult>(queryContext, context.Request);

            var settings = new ODataQuerySettings
            {
                // N.B EnsureStableOrdering is required for pagination when the source query is not ordered from backend or 
                // when the OData query does not contain order (from front-end). EnsureStableOrdering orders the source query for PKs
                // just to ensure the pagination is correct. If Skip or take is present in the query without an ordering EF throws exception.
                //EnsureStableOrdering = queryOptions.OrderBy == null && !QueryableOrderExpressionVisitor.IsOrdered(source.Expression),
                
                EnableConstantParameterization = true
            };

            var count = default(long?);
            if (computeCount)
            {
                count = await source.LongCountAsync(context.RequestAborted);
            }

            var filteredQuery = queryOptions.ApplyTo(source, settings).Cast<TResult>();
            return new PageResult<TResult>(await filteredQuery.ToListAsync(context.RequestAborted), null, count);
        }
    }
}
