using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TechRadar.Api.Core;
using TechRadar.Api.Interfaces;

namespace TechRadar.Api.Features
{
    public class RemoveBlip
    {
        public class Request : IRequest<Response> { 
            public Guid BlipId { get; set; }        
        }

        public class Response: ResponseBase { }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly ITechRadarDbContext _context;

            public Handler(ITechRadarDbContext context){
                _context = context;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken) {
            
                var blip = await _context.Blips.FindAsync(request.BlipId);

                _context.Blips.Remove(blip);

                await _context.SaveChangesAsync(cancellationToken);
			    
                return new () { 

                };
            }
        }
    }
}
