using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
using Windows.UI.Core;
using Windows.UI.ViewManagement; 

namespace ReduceReuseRecycle
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Rectangle _gameBoundaries;
        private Boolean _windowIsSnapped;
        private gameObjects _gameObjects;

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



            // Abstract to Level Defined Method or some ish.....

            var random = new Random();

            var trashItem1Texture = Content.Load<Texture2D>("trash1");
            var trashItemLocation = new Vector2(_gameBoundaries.Width / 2 - random.Next(-800, 1000), 0f);
            var trashItem1 = new trashItem(trashItem1Texture, trashItemLocation, _gameBoundaries);
            trashItem1.setTrashType(TrashType.Trash);

            var recycleItem1Texture = Content.Load<Texture2D>("recycle1");
            var recylceItemLocation = new Vector2(_gameBoundaries.Width / 2 - random.Next(-1000, 800), 0f);
            var recycleItem1 = new trashItem(recycleItem1Texture, recylceItemLocation, _gameBoundaries);
            recycleItem1.setTrashType(TrashType.Recycle);

            //Abstract to Level Defined Method or some ish.....

            var trashBinTexture = Content.Load<Texture2D>("trashBin");
            var trashBinLocation = new Vector2(_gameBoundaries.Width/2 + 50f, _gameBoundaries.Height - 100f);
            var trashBin = new playerBin(trashBinTexture, trashBinLocation, _gameBoundaries); 
            trashBin.setBinType(TrashType.Trash); 

            var recycleBinTexture = Content.Load<Texture2D>("recycleBin");
            var recycleBinLocation = new Vector2(_gameBoundaries.Width/2 - 50f, _gameBoundaries.Height - 100f);
            var recycleBin = new playerBin(recycleBinTexture, recycleBinLocation, _gameBoundaries);
            recycleBin.setBinType(TrashType.Recycle); 
            
            var iconTexture = new Texture2D(GraphicsDevice, 100, 100); 
            iconTexture = Content.Load<Texture2D>("RecyCloneIcon");
            var icon = new Icon(iconTexture, Vector2.Zero, _gameBoundaries); 


            // Score Creation
            var spriteFontTexture = Content.Load<SpriteFont>("font");
            var score = new Score(spriteFontTexture, _gameBoundaries);

            _gameObjects = new gameObjects(); 
            _gameObjects.TrashBin = trashBin;
            _gameObjects.RecycleBin = recycleBin; 
            _gameObjects.Score = score;
            _gameObjects.Icon = icon;
            _gameObjects.trashItem1 = trashItem1;
            _gameObjects.recycleItem1 = recycleItem1;
            _gameObjects.Score = score; 
        }
        protected override void UnloadContent()
        {
            
        }
        protected override void Update(GameTime gameTime)
        {
            _windowIsSnapped = checkGameWindow();
            if (Keyboard.GetState().IsKeyDown(Keys.R) || ((_gameObjects.Score.gameOver == true) && (Mouse.GetState().LeftButton == ButtonState.Pressed || TouchPanel.GetState().FirstOrDefault().State != TouchLocationState.Invalid)))
            {
                
                
            }
            else if (_gameObjects.Score.gameOver == false)
            {
                _gameObjects.TrashBin.Update(gameTime, _gameObjects);
                _gameObjects.RecycleBin.Update(gameTime, _gameObjects); 
                _gameObjects.Score.Update(gameTime, _gameObjects);
                _gameObjects.recycleItem1.Update(gameTime, _gameObjects);
                _gameObjects.trashItem1.Update(gameTime, _gameObjects);
                _gameObjects.Score.Update(gameTime, _gameObjects); 
            }

            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(43,85,5));
            _spriteBatch.Begin(); 
            //MustBegin
            if (_windowIsSnapped)
            {
                var IconLocation = new Vector2((_gameBoundaries.Width - _gameObjects.Icon.Width) / 2, (_gameBoundaries.Height - _gameObjects.Icon.Height) / 2);
                _gameObjects.Icon.Location = IconLocation;
                _gameObjects.Icon.Draw(_spriteBatch);
            }
            else
            {
                _gameObjects.TrashBin.Draw(_spriteBatch);
                _gameObjects.RecycleBin.Draw(_spriteBatch);
                _gameObjects.trashItem1.Draw(_spriteBatch);
                _gameObjects.recycleItem1.Draw(_spriteBatch);
                _gameObjects.Score.Draw(_spriteBatch); 

            }
            //MustEnd
            _spriteBatch.End(); 
            base.Draw(gameTime);
        }
        private Boolean checkGameWindow()
        {
              Boolean lSnapped = false; 
            if (ApplicationView.Value == ApplicationViewState.Snapped)
            {
                lSnapped = true;
                _gameBoundaries = new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height);
            }
            else if (ApplicationView.Value == ApplicationViewState.Filled)
            {
                lSnapped = true;
                _gameBoundaries = new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height);
            }
            else if (ApplicationView.Value == ApplicationViewState.FullScreenLandscape)
            {
                lSnapped = false;
                _gameBoundaries = new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height);
            }
            return lSnapped; 
         }
    }
}
