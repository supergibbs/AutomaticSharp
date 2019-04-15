using System.Runtime.Serialization;

namespace AutomaticSharp.Models
{
    public enum VehicleEventType
    {
        Unknown,
        [EnumMember(Value = "speeding")]
        Speeding,
        [EnumMember(Value = "hard_accel")]
        HardAcceleration,
        [EnumMember(Value = "hard_brake")]
        HardBrake
    }
}