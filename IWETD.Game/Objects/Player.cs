using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IWETD.Game.Attributes;
using IWETD.Game.Input;
using IWETD.Game.IO.Saves;
using IWETD.Game.Objects.Drawables;
using IWETD.Game.Screens.Rooms;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Input.Bindings;
using osu.Framework.Input.Events;
using osuTK;
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

        private Vector2 _momentun;
        
        private Room Room { get; set; }

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

        public void SetRoom(Room room, Vector2 position)
        {
            Room = room;

            if (room.IsLoaded != true)
                return;

            Position = position;

            Room.AddPlayer(this);
        }

        protected override void Update()
        {
            if (!IsColliding())
            {
                X += _momentun.X;
                Y = Math.Clamp(Y + 0.35f, 0, Room.ObjectGrid.Size.Y);
            }
            else
            {
                // let's check where are we colliding.
                if (_momentun.X > 0)
                    X += _momentun.X;
                else if (_momentun.X < 0)
                    X -= -_momentun.X;

                if (_momentun.Y > 0)
                    Y += _momentun.Y;
                else if (_momentun.Y < 0)
                    Y -= _momentun.Y;

                Console.WriteLine(_momentun);
            }


            base.Update();
        }
        
        private bool IsColliding()
        {
            foreach (var obj in Room.Objects)
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
                    _momentun.X -= 0.35f;
                    break;
                
                case PlayerAction.Right:
                    _momentun.X += 0.35f;
                    break;
            }

            return true;
        }

        public void OnReleased(PlayerAction action)
        {
            switch (action)
            {
                // the rest will break the direction regardless of it being a movement command or not.
                case PlayerAction.Left:
                    _momentun.X += 0.35f;
                    break;
                
                case PlayerAction.Right:
                    _momentun.X -= 0.35f;
                    break;
            }
        }
    }
}
