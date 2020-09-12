using System.Threading.Tasks;
using Abp.Application.Services;
using Ideas.Authorization.Accounts.Dto;

namespace Ideas.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
