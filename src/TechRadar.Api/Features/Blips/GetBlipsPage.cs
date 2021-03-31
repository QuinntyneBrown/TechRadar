using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using TechRadar.Api.Extensions;
using TechRadar.Api.Core;
using TechRadar.Api.Interfaces;
using TechRadar.Api.Extensions;
using Microsoft.EntityFrameworkCore;

namespace TechRadar.Api.Features
{
    public class GetBlipsPage
    {
        public class Request: IRequest<Response>
        {
            public int PageSize { get; set; }
            public int Index { get; set; }
        }

        public class Response: ResponseBase
        {
            public int Length { get; set; }
            public List<BlipDto> Entities { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly ITechRadarDbContext _context;
        
            public Handler(ITechRadarDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var query = from blip in _context.Blips
                    select blip;
                
                var length = await _context.Blips.CountAsync();
                
                var blips = await query.Page(request.Index, request.PageSize)
                    .Select(x => x.ToDto()).ToListAsync();
                
                return new()
                {
                    Length = length,
                    Entities = blips
                };
            }
            
        }
    }
}
