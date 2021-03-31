using System;

namespace TechRadar.Api.Models
{
    public class Blip
    {
        public Guid BlipId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public BlipStatus Status { get; set; }
        public BlipType Type { get; set; }
    }
}
