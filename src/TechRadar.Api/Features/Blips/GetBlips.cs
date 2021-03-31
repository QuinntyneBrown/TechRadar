using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using TechRadar.Api.Core;
using TechRadar.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TechRadar.Api.Features
{
    public class GetBlips
    {
        public class Request: IRequest<Response> { }

        public class Response: ResponseBase
        {
            public List<BlipDto> Blips { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly ITechRadarDbContext _context;
        
            public Handler(ITechRadarDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new () {
                    Blips = await _context.Blips.Select(x => x.ToDto()).ToListAsync()
                };
            }
            
        }
    }
}
