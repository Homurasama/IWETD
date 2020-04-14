using System;
using System.IO;
using IWETD.Game.IO.Saves;
using IWETD.Game.Objects.Drawables;

namespace IWETD.Game.Objects
{
    public class Player : DrawableGameObject, IPlayer
    {
        // Player Properties
        public virtual string CurrentSaveFile { get; set; } = "save1";

        public virtual int MaxJumpCount { get; set; } = 2;

        public virtual int JumpCount { get; set; } = 0;

        public virtual bool Dead { get; set; } = false;

        public virtual GravityType Gravity { get; set; } = GravityType.Down;

        // Savefile Properties

        public SaveManager SaveManager = new SaveManager(Path.Combine(Directory.GetCurrentDirectory(), "data"));

        public SaveFile SaveFile => SaveManager.Read(CurrentSaveFile);

        public Player(GameObject gameObject)
            : base(gameObject)
        {

        }

        // Events
        public virtual bool OnDeath()
        {
            return true;
        }

        public virtual bool OnJump()
        {
            if (JumpCount++ <= MaxJumpCount) JumpCount = 0;
            return true;
        }
    }
}
