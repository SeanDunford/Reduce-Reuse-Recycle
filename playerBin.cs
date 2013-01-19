using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReduceReuseRecycle
{
    public class playerBin : Sprite
    {
       private Texture2D _trashBinTexture;
       private Vector2 _trashBinLocation;
       private Rectangle _gameBoundaries;
       private TrashType _binType;
       private Boolean _mouseMove;
       private Vector2 touchPosition = Vector2.Zero;

       public playerBin(Texture2D aTrashBinTexture, Vector2 aTrashBinLocation, Rectangle aGameBoundaries): base(aTrashBinTexture, aTrashBinLocation, aGameBoundaries)
        {
            _trashBinLocation = aTrashBinLocation;
            _trashBinTexture = aTrashBinTexture;
            _gameBoundaries = aGameBoundaries;
            Velocity = Vector2.Zero; 
            //_binType = aBinType; 
        }
        public void setBinType(TrashType aBinType)
        {
            _binType = aBinType; 
        }
        public override void Update(GameTime aGameTime, gameObjects aGameObjects)
       {
           if ((Location.X == 0 || Location.X == (gameBoundaries.Width - _texture.Width)))
           {
               if (Velocity != Vector2.Zero)
               {
                   var newVelocity = Vector2.Zero;
                   Velocity = newVelocity;
                   _mouseMove = false;
               }
           }
           var touchPoint = TouchPanel.GetState().FirstOrDefault();
           if (touchPoint.State != TouchLocationState.Invalid)
           {
               _mouseMove = true;
               touchPosition = new Vector2(touchPoint.Position.X, 0f);
           }
           else if (Mouse.GetState().LeftButton == ButtonState.Pressed)
           {   // Add touch 
               //Mouse overrides keyboard input
               //Mouse and Touch shoudl be handled as same event sort of so they don't compete 
               _mouseMove = true;
               touchPosition = new Vector2(Mouse.GetState().X , 0f);
           }
           if (_mouseMove)
           {
               if ((touchPosition.X < (Location.X + Width / 2) + 10f) && (touchPosition.X > (Location.X + Width / 2) - 10f))
               {
                   _mouseMove = false;
                   Velocity = Vector2.Zero;

               }
               else if (touchPosition.X > Location.X + Width / 2)
               {
                   var newVelocity = new Vector2(3f, 0);
                   Velocity = newVelocity;
               }
               else if (touchPosition.Y < Location.Y + Height / 2)
               {
                   var newVelocity = new Vector2(-3f, 0);
                   Velocity = newVelocity;
               }
           }
           else if (Keyboard.GetState().IsKeyDown(Keys.Left))
                    {
                        var newVelocity = new Vector2(-3f, 0);
                        Velocity = newVelocity;
                    }
                    else if (Keyboard.GetState().IsKeyDown(Keys.Right))
                    {
                        var newVelocity = new Vector2(3f, 0);
                        Velocity = newVelocity;
                    }
                    else if (Keyboard.GetState().IsKeyDown(Keys.Up) || Keyboard.GetState().IsKeyDown(Keys.Down))
                    {
                        var newVelocity = Vector2.Zero;
                        Velocity = newVelocity;
                    }

           base.Update(aGameTime, aGameObjects);
                }        
       protected override void CheckBounds()
       {
           Location.Y = MathHelper.Clamp(Location.Y, 0, (gameBoundaries.Height - _texture.Height));
       }

    }
   
}
