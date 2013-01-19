using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ReduceReuseRecycle
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Rectangle _gameBoundaries;
        private SpriteFont _spriteFont; 

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize() 
        {
            IsMouseVisible = true;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _gameBoundaries = new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height);

            var trashBinTexture = Content.Load<Texture2D>("trashBin");
            var trashBinLocation = new Vector2(10f, _gameBoundaries.Height / 2);
            var trashBin = new playerBin(trashBinTexture, trashBinLocation, _gameBoundaries, binType.Trash); 

            var recycleBinTexture = Content.Load<Texture2D>("recycleBin");
            var trashItem1 = Content.Load<Texture2D>("trash1");
            var recycleItem1 = Content.Load<Texture2D>("recycle");

            // Score Creation
            _spriteFont = Content.Load<SpriteFont>("font");
            _score = new Score(_spriteFont, _gameBoundaries);

        }

        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
        

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
        }
    }
}
