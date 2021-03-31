using System;

namespace TechRadar.Api.Models
{
    public class Blip
    {
        public Guid BlipId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public BlipStatus Status { get; private set; }
        public BlipType Type { get; private set; }

        public Blip(string name)
        {
            Name = name;
        }

        public Blip(string name, string description, BlipStatus status, BlipType type)
        {
            Name = name;
            Description = description;
            Status = status;
            Type = type;
        }

        public Blip()
        {

        }

        public Blip Update(string name, string description, BlipStatus status, BlipType type)
        {
            Name = name;
            Description = description;
            Status = status;
            Type = type;
            return this;
        }
    }
}
