﻿using Evento.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evento.Infrastructure.Services
{
    public interface ITicketService
    {
        Task<IEnumerable<TicketDetailsDTO>> GetForUserAsync(Guid userId);

        Task<TicketDTO> GetAsync(Guid userId, Guid eventId, Guid ticketId);

        Task PurchaseAsync(Guid userId, Guid eventId, int amount);

        Task CancelAsync(Guid userId, Guid eventId, int amount);
    }
}
