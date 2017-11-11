using Evento.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Infrastructure.Services
{
    public interface IJwtHandler
    {
        JwtDTO CreateToken(Guid userId, string role);
    }
}
