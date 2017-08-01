using System.Threading.Tasks;

namespace Eventador.Queries
{
    public interface IAsyncQuery<T>
    {
        Task<T> ExecuteAsync();
    }

    public interface IAsyncQuery<in TIn, T>
    {
        Task<T> ExecuteAsync(TIn parameters);
    }
}