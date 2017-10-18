using System.Threading.Tasks;
using SimpleCQRS.Infrastracture;

namespace SimpleCQRS.Queries.Handlers
{
    public class TestQueryHandler : IQueryHandler<TestQuery, int>
    {
        public int Handle(TestQuery query)
        {
            return query.X * query.Y;
        }

        public Task<int> HandleAsync(TestQuery query)
        {
            return Task.FromResult(query.X * query.Y);
        }
    }
}