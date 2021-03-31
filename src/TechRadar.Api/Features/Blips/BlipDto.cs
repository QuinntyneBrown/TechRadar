using System;
using TechRadar.Api.Models;

namespace TechRadar.Api.Features
{
    public class BlipDto
    {
        public Guid? BlipId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public BlipStatus Status { get; set; }
        public BlipType Type { get; set; }
    }
}
