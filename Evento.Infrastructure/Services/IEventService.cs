﻿using Evento.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Infrastructure.Services
{
    public interface IEventService
    {
        Task<EventDTO> GetAsync(Guid id);

        Task<EventDTO> GetAsync(string name);

        Task<IEnumerable<EventDTO>> BrowseAsync(string name = null);

        Task AddTicketsAsync(Guid eventId, int amount, decimal price);

        Task CreateAsync(Guid id, string name, string description, DateTime startDate, DateTime endDate);

        Task UpdateAsync(Guid id, string name, string description);

        Task DeleteAsync(Guid id);
    }
}
