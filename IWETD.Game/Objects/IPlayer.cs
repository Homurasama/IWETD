using IWETD.Game.Interfaces;

namespace IWETD.Game.Objects
{
    public interface IPlayer
    {
        public string CurrentSaveFile { get; set; }

        public bool Dead { get; set; }

        public int MaxJumpCount { get; set; }

        public int JumpCount { get; set; }

        public GravityType Gravity { get; set; }
    }

    public enum GravityType
    {
        Down,
        Left,
        Right,
        Up
    }
}