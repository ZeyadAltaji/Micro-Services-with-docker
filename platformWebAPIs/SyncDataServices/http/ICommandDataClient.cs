using DTOs;
using System.Threading.Tasks;

namespace platformWebAPIs.SyncDataServices.http
{
    public interface ICommandDataClient
    {
        Task SendplatformsCommand(PlatfromsReadDto readDto);

    }
}
