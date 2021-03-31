using TechRadar.Api.Models;

namespace TechRadar.Api.Features
{
    public static class BlipExtensions
    {
        public static BlipDto ToDto(this Blip blip)
        {
            return new ()
            {
                BlipId = blip.BlipId,
                Name = blip.Name,
                Description = blip.Description,
                Status = blip.Status,
                Type = blip.Type
            };
        }
        
    }
}
