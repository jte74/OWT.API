using OWT.Domain.Models;
using OWT.Domain.Models.Requests.Auth;
using System.Threading.Tasks;

namespace OWT.Domain.Interfaces
{
    public interface IAuthBusiness
    {
        Task<TokenModel> ConnectUser(ConnectUserRequest request);
    }
}
