using IWETD.Game.IO;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;

namespace IWETD.Game.Objects
{
    public class DrawableGameObject : CompositeDrawable, IGameObject
    {
        private GameObject _gameObject = new GameObject();

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
        private void Load(TextureStore store)
        {
            CreateHitbox();
            AddInternal(Hitbox);
            
            AddInternal(new Sprite
            {
                Texture = store.Get("Tile/" + GameObject.Texture),
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
