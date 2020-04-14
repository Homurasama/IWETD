using IWETD.Game.IO;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osuTK;

namespace IWETD.Game.Objects.Drawables
{
    public class DrawableGameObject : CompositeDrawable, IGameObject
    {
        private GameObject _gameObject = new GameObject();

        private Sprite _sprite;
        
        [Resolved]
        private TextureStore _store { get; set; }

        public GameObject GameObject
        {
            get => _gameObject;
            private set
            {
                if (value != null && _gameObject == value)
                    return;

                _gameObject = value;

                switch (value?.Hitbox)
                {
                    case "Square":
                        Hitbox = new Box();
                        break;
                    case "Triangle":
                        Hitbox = new Triangle();
                        break;
                }
                
                Size = new Vector2(24);
                Position = new Vector2(value?.X ?? 0, value?.Y ?? 0);
                Rotation = value?.Rotation ?? 0;

                if (IsLoaded)
                {
                    _sprite.Texture = _store.Get("Tile/" + GameObject.Texture);
                }
            }
        }

        public Drawable Hitbox;

        public virtual bool Solid => true;

        public DrawableGameObject(GameObject gameObject)
        {
            GameObject = gameObject;
        }
        
        public DrawableGameObject(string objectString)
        {
            GameObject = GameParser.DeserializeObject<GameObject>(objectString);
        }

        [BackgroundDependencyLoader]
        private void Load()
        {
            CreateHitbox();
            AddInternal(Hitbox);
            
            AddInternal(_sprite = new Sprite
            {
                Texture = _store.Get("Tile/" + GameObject.Texture),
                Size = Size,
                FillMode = FillMode.Stretch
            });
        }

        private void CreateHitbox()
        {
            Hitbox.With(d =>
            {
                d.Alpha = 0;
                d.AlwaysPresent = true;
                d.Size = Size;
            });
        }

        // TODO: Player should be cached.
        public bool CheckHit(Drawable player)
            => player.BoundingBox.IntersectsWith(Hitbox.BoundingBox);
    }
}
