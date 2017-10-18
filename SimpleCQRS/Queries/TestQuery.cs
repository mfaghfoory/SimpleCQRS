using SimpleCQRS.Infrastracture;

namespace SimpleCQRS.Queries
{
    public class TestQuery : IQuery
    {
        public int X { get; set; }

        public int Y { get; set; }
    }
}