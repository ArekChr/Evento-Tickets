using Evento.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Infrastructure.Services
{
    public interface IUserService
    {
        Task<AccountDTO> GetAccountAsync(Guid userId);

        Task RegisterAsync(Guid userId, string email, string name, string password, string role = "user");

        Task<TokenDTO> LoginAsync(string email, string password);
    }
}
