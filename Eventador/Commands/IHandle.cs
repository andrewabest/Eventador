using System.Threading.Tasks;

namespace Eventador.Commands
{
    public interface IHandle<in T> where T : IDomainCommand
    {
        Task Handle(T command);
    }
}