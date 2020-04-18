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
using osu.Framework.Graphics.Shapes;
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

        private Box _topCollision;
        private Box _botCollision;
        private Box _lefCollision;
        private Box _rigCollision;

        public Player(GameObject gameObject)
            : base(gameObject)
        {
            Colour = Color4.Red;

            AddInternal(CalculatePosition(_topCollision = new Box(), Vector2.UnitY).With(d => d.Height = 3));
            AddInternal(CalculatePosition(_botCollision = new Box(), -Vector2.UnitY).With(d => d.Height = 3));
            AddInternal(CalculatePosition(_rigCollision = new Box(), Vector2.UnitX).With(d => d.Width = 3));
            AddInternal(CalculatePosition(_lefCollision = new Box(), -Vector2.UnitX).With(d => d.Width = 3));
        }

        // we only want to check for 1px
        private Drawable CalculatePosition(Drawable drawable, Vector2 position) =>
            drawable.With(d =>
            {
                d.Size = Size;

                if (position.X < 0 || position.Y < 0)
                {
                    d.Anchor = Anchor.BottomRight;
                    d.Origin = Anchor.BottomRight;
                }
            });

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
            _momentun.Y = 0.35f;
        }

        protected override void UpdateAfterChildren()
        {
            var colliding = IsColliding();

            if (!colliding.Item1)
            {
                X += _momentun.X;
                Y = Math.Clamp(Y + _momentun.Y, 0, Room.ObjectGrid.Size.Y);
            }
            else
            {
                // let's check where are we colliding.
                foreach (var type in colliding.Item2)
                {
                    switch (type)
                    {
                        case GravityType.Up:
                            Y -= 0.35f;
                            
                            break;
                        
                        case GravityType.Down:
                            Y += 0.35f;
                            
                            break;
                        
                        case GravityType.Left:
                            X -= 0.35f;
                            
                            break;
                        
                        case GravityType.Right:
                            X += 0.35f;
                            
                            break;
                    }
                }
            }

            base.UpdateAfterChildren();
        }
        
        private (bool, GravityType[]) IsColliding()
        {
            foreach (var obj in Room.Objects)
            {
                if (Hitbox.ScreenSpaceDrawQuad.AABBFloat.IntersectsWith(obj.ScreenSpaceDrawQuad.AABBFloat))
                {
                    var top = _topCollision.ScreenSpaceDrawQuad.AABBFloat.IntersectsWith(obj.ScreenSpaceDrawQuad.AABBFloat);
                    var bot = _botCollision.ScreenSpaceDrawQuad.AABBFloat.IntersectsWith(obj.ScreenSpaceDrawQuad.AABBFloat);
                    var lef = _lefCollision.ScreenSpaceDrawQuad.AABBFloat.IntersectsWith(obj.ScreenSpaceDrawQuad.AABBFloat);
                    var rig = _rigCollision.ScreenSpaceDrawQuad.AABBFloat.IntersectsWith(obj.ScreenSpaceDrawQuad.AABBFloat);
                    List<GravityType> type = new List<GravityType>();
                    
                    if (top)
                        type.Add(GravityType.Up);
                    if (bot)
                        type.Add(GravityType.Down);
                    
                    if (lef)
                        type.Add(GravityType.Left);
                    if (rig)
                        type.Add(GravityType.Right);
                    
                    return (true, type.ToArray());
                }
            }

            return (false, Array.Empty<GravityType>());
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
