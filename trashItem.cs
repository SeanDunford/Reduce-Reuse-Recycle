using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReduceReuseRecycle
{
    public class trashItem : Sprite
    {
        private TrashType _trashType;
        private Texture2D _trashBinTexture;
        private Vector2 _trashBinLocation;
        private Rectangle _gameBoundaries;

        public trashItem(Texture2D aTrashBinTexture, Vector2 aTrashBinLocation, Rectangle aGameBoundaries): base(aTrashBinTexture, aTrashBinLocation, aGameBoundaries)
        {
            _trashBinLocation = aTrashBinLocation;
            _trashBinTexture = aTrashBinTexture;
            _gameBoundaries = aGameBoundaries;
            Velocity = Vector2.Zero; 
        }
        public void setTrashType(TrashType aTrashType)
        {
            _trashType = aTrashType; 
        }
        protected override void CheckBounds()
        {
 	        //Implement dis shit
        }
        public override void Update(GameTime aGameTime, gameObjects aGameObjects)
        {
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)  //Change to Game Started.....
            {
                var newVelocity = new Vector2(0f, 5f);
                Velocity = newVelocity;
            }
            base.Update(aGameTime, aGameObjects);
        }

    }
}
