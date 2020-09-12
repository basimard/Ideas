using System.Threading.Tasks;
using Abp.Application.Services;
using Ideas.Sessions.Dto;

namespace Ideas.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
