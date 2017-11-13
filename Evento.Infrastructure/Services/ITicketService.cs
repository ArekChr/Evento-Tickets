using Evento.Infrastructure.DTO;
using System;
using System.Threading.Tasks;

namespace Evento.Infrastructure.Services
{
    public interface ITicketService
    {
        Task<TicketDTO> GetAsync(Guid userId, Guid eventId, Guid ticketId);

        Task PurchaseAsync(Guid userId, Guid eventId, int amount);

        Task CancelAsync(Guid userId, Guid eventId, int amount);
    }
}
