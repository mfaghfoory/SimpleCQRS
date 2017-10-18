using SimpleCQRS.Infrastracture;

namespace SimpleCQRS.Commands
{
    public class TestCommand : ICommand
    {
        public string Name { get; set; }
    }
}