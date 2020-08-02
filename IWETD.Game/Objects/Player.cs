using System;
using System.IO;
using IWETD.Game.Attributes;
using IWETD.Game.Input;
using IWETD.Game.IO.Saves;
using IWETD.Game.Objects.Drawables;
using IWETD.Game.Screens.Rooms;
using osu.Framework.Input.Bindings;
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
        
        private Vector2 velocity = Vector2.Zero;
        private float gravity = 0.03f;
        private float walkSpeed = 1;

        private int left;
        private int right;
        private bool jump;
        
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

        protected override void UpdateAfterChildren()
        {
            base.UpdateAfterChildren();

            var elapsedFrameTime = Clock.ElapsedFrameTime;
            var timeDifference = elapsedFrameTime / 5;

            var direction = right - left;

            velocity.X = direction * walkSpeed;
            velocity.Y = velocity.Y + gravity;
            
            foreach (var roomObject in Room.Objects)
            {
                if (roomObject.BoundingBox.IntersectsWith(BoundingBox.Offset(0, 1)) && jump)
                {
                    velocity.Y = -3;
                }
            }

            #region Horizontal collision checking
            foreach (var roomObject in Room.Objects)
            {
                if (!roomObject.BoundingBox.IntersectsWith(BoundingBox.Offset(velocity.X, 0))) continue;

                while (!roomObject.BoundingBox.IntersectsWith(BoundingBox.Offset(Math.Sign(velocity.X), 0)))
                {
                    X = X + Math.Sign(velocity.X) * (float) timeDifference;
                }

                velocity.X = 0;
            }

            X = X + velocity.X * (float) timeDifference;
            #endregion

            #region Vertical collision checking
            foreach (var roomObject in Room.Objects)
            {
                if (!roomObject.BoundingBox.IntersectsWith(BoundingBox.Offset(0, velocity.Y))) continue;

                while (!roomObject.BoundingBox.IntersectsWith(BoundingBox.Offset(0, Math.Sign(velocity.Y))))
                {
                    Y = Y + Math.Sign(velocity.Y);
                }

                velocity.Y = 0;
            }

            Y = Y + velocity.Y * (float) timeDifference;
            #endregion
        }

        public bool OnPressed(PlayerAction action)
        {
            switch (action)
            {
                case PlayerAction.Left:
                    left = 1;
                    break;
                
                case PlayerAction.Right:
                    right = 1;
                    break;
                
                case PlayerAction.Jump:
                    jump = true;
                    break;
            }

            return true;
        }

        public void OnReleased(PlayerAction action)
        {
            switch (action)
            {
                case PlayerAction.Left:
                    left = 0;
                    break;
                
                case PlayerAction.Right:
                    right = 0;
                    break;
                
                case PlayerAction.Jump:
                    jump = false;
                    break;
            }
        }
        
        private int GetIntValue(bool value)
            => value ? 1 : 0;
    }
}
