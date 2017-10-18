using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace SimpleCQRS.Infrastracture
{
    public class AppBus
    {
        private readonly ServiceProvider _serviceProvider;

        public AppBus(ServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void SendCommand<TCommand>(TCommand command) where TCommand : ICommand
        {
            var commandHandler = _serviceProvider.GetService<ICommandHandler<TCommand>>();
            if (commandHandler != null)
                commandHandler.Handle(command);
            else
                throw new NotImplementedException();
        }

        public Task SendCommandAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            var commandHandler = _serviceProvider.GetService<ICommandHandler<TCommand>>();
            if (commandHandler != null)
                return commandHandler.HandleAsync(command);
            return Task.CompletedTask;
        }

        public TResult SendQuery<TQuery, TResult>(TQuery query) where TQuery : IQuery
        {
            var queryHandler = _serviceProvider.GetService<IQueryHandler<TQuery, TResult>>();
            if (queryHandler != null)
                return queryHandler.Handle(query);
            return default(TResult);
        }

        public Task<TResult> SendQueryAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery
        {
            var queryHandler = _serviceProvider.GetService<IQueryHandler<TQuery, TResult>>();
            if (queryHandler != null)
                return queryHandler.HandleAsync(query);
            return null;
        }
    }
}