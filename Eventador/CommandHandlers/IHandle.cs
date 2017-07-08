using System.Threading.Tasks;
using Eventador.Commands;

namespace Eventador.CommandHandlers
{
    public interface IHandle<in T> where T: IDomainCommand
    {
        Task Handle(T command);
    }
}