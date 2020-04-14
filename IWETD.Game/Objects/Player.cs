using System;
using System.IO;
using IWETD.Game.Attributes;
using IWETD.Game.Input;
using IWETD.Game.IO.Saves;
using IWETD.Game.Objects.Drawables;
using IWETD.Game.Screens;
using osu.Framework.Allocation;
using osu.Framework.Input.Bindings;
using osu.Framework.Input.Events;
using osuTK.Graphics;

namespace IWETD.Game.Objects
{
    public class Player : DrawableGameObject, IPlayer, IKeyBindingHandler<PlayerAction>
    {
        #region Player Properties
        public virtual string CurrentSaveFile { get; set; } = "save1";

        [GameProperty]
        public virtual int MaxJumpCount { get; set; } = 2;

        [GameProperty]
        public virtual int JumpCount { get; set; } = 0;

        [GameProperty]
        public virtual bool Dead { get; set; } = false;

        [GameProperty]
        public virtual GravityType Gravity { get; set; } = GravityType.Down;
        #endregion

        #region SaveFile Properties
        public SaveManager SaveManager = new SaveManager(Path.Combine(Directory.GetCurrentDirectory(), "data"));

        public SaveFile SaveFile => SaveManager.Read(CurrentSaveFile);
        #endregion
        
        [Resolved]
        private Room _room { get; set; }

        public Player(GameObject gameObject)
            : base(gameObject)
        {
            Colour = Color4.Red;
        }

        #region Events
        public virtual bool OnDeath() => true;

        public virtual bool OnJump()
        {
            if (JumpCount++ <= MaxJumpCount) 
                JumpCount = 0;

            return true;
        }
        #endregion
        
        private float _direction;

        protected override void Update()
        {
            if (!IsColliding())
            {
                X = Math.Clamp(X + _direction, 0, _room.ObjectGrid.Size.X);
                Y = Math.Clamp(Y + 0.35f, 0, _room.ObjectGrid.Size.Y);
            }
            else
            {
                X -= 0.35f;
                Y -= 1f;
            }

            base.Update();
        }
        
        private bool IsColliding()
        {
            foreach (var obj in _room.Objects)
            {
                if (BoundingBox.IntersectsWith(obj.BoundingBox))
                    return true;
            }

            return false;
        }

        public bool OnPressed(PlayerAction action)
        {
            switch (action)
            {
                case PlayerAction.Left:
                    _direction = -0.35f;
                    break;
                
                case PlayerAction.Right:
                    _direction = 0.35f;
                    break;
            }

            return true;
        }

        public void OnReleased(PlayerAction action)
        {
            _direction = 0;
        }
    }
}
