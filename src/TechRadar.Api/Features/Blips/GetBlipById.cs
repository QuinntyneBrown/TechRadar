using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TechRadar.Api.Core;
using TechRadar.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TechRadar.Api.Features
{
    public class GetBlipById
    {
        public class Request: IRequest<Response>
        {
            public Guid BlipId { get; set; }
        }

        public class Response: ResponseBase
        {
            public BlipDto Blip { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly ITechRadarDbContext _context;
        
            public Handler(ITechRadarDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new () {
                    Blip = (await _context.Blips.SingleOrDefaultAsync()).ToDto()
                };
            }
            
        }
    }
}
