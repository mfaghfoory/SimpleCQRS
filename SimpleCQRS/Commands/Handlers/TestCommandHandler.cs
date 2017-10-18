using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SimpleCQRS.Infrastracture;

namespace SimpleCQRS.Commands.Handlers
{
    public class TestCommandHandler : ICommandHandler<TestCommand>
    {
        private readonly ILogger<TestCommandHandler> _logger;

        public TestCommandHandler(ILogger<TestCommandHandler> logger)
        {
            _logger = logger;
        }

        public void Handle(TestCommand command)
        {
            _logger.LogInformation(command.Name);
        }

        public Task HandleAsync(TestCommand command)
        {
            _logger.LogInformation(command.Name);
            return Task.CompletedTask;
        }
    }
}