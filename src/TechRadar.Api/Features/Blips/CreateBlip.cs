using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TechRadar.Api.Models;
using TechRadar.Api.Core;
using TechRadar.Api.Interfaces;

namespace TechRadar.Api.Features
{
    public class CreateBlip
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Blip).NotNull();
                RuleFor(request => request.Blip).SetValidator(new BlipValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public BlipDto Blip { get; set; }
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
                var blip = new Blip();
                
                _context.Blips.Add(blip);

                blip.Name = request.Blip.Name;
                blip.Description = request.Blip.Description;
                blip.Status = request.Blip.Status;
                blip.Type = request.Blip.Type;

                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Blip = blip.ToDto()
                };
            }
            
        }
    }
}
