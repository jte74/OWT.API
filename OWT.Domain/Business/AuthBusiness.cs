using Microsoft.Extensions.Options;
using OWT.Domain.Interfaces;
using OWT.Domain.Models;
using OWT.Domain.Models.Config;
using OWT.Domain.Models.Requests.Auth;
using OWT.Domain.Tools;
using System.Threading.Tasks;

namespace OWT.Domain.Business
{
    public class AuthBusiness : IAuthBusiness
    {
        public IContactManager _contactManager;
        private readonly IOptions<JwtSettings> _jwtSettings;

        public AuthBusiness(IContactManager contactManager, IOptions<JwtSettings> jwtSettings)
        {
            _contactManager = contactManager;
            _jwtSettings = jwtSettings;
        }

        public async Task<TokenModel> ConnectUser(ConnectUserRequest request)
        {
            TokenModel result = null;
            var existingContact = await _contactManager.AuthenticateContact(request.Mail, request.Firstname);
            if (existingContact != null)
            {
                result = new TokenModel
                {
                    Mail = existingContact.Email,
                    Token = TokenTool.GenerateJwt(existingContact, _jwtSettings.Value)
                };
            }

            return result;
        }
    }
}
