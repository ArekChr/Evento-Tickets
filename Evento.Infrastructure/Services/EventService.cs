﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Evento.Infrastructure.DTO;
using Evento.Core.Repositories;
using System.Linq;

namespace Evento.Infrastructure.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<EventDTO> GetAsync(Guid id)
        {
            var @event = await _eventRepository.GetAsync(id);
            if(@event == null)
            {
                return null;
            }

            return new EventDTO
            {
                Id = @event.Id,
                Name = @event.Name
            };
        }

        public async Task<EventDTO> GetAsync(string name)
        {
            var @event = await _eventRepository.GetAsync(name);

            return new EventDTO
            {
                Id = @event.Id,
                Name = @event.Name
            };
        }

        public async Task<IEnumerable<EventDTO>> BrowseAsync(string name = null)
        {
            var @events = await _eventRepository.BrowseAsync(name);

            return events.Select( @event => new EventDTO
            {
                Id = @event.Id,
                Name = @event.Name
            });
        }

        public async Task CreateAsync(Guid id, string name, string description, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Guid id, string name, string description)
        {
            throw new NotImplementedException();
        }
        public async Task AddTicketsAsync(Guid eventId, int amount, decimal price)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }


    }
}
