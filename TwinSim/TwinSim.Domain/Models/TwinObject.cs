using System;
namespace TwinSim.Domain.Models
{
    public record Position(float x, float y, float z);

    public enum Status
    {
        Active,
        Inactive,
        Error
    }

    public class TwinObject
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string Name { get; init; } = string.Empty;
        public Position Position { get; set; } = new(0, 0, 0);
        public Status Status { get; set; } = Status.Active;
    }
}