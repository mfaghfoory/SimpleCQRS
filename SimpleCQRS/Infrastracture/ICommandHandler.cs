using System.Threading.Tasks;

namespace SimpleCQRS.Infrastracture
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        void Handle(TCommand command);

        Task HandleAsync(TCommand command);
    }
}