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
        private Texture2D _trashItemTexture;
        private Vector2 _trashItemLocation;
        private Rectangle _gameBoundaries;
        private Random _random = new Random();

        public trashItem(Texture2D aTrashItemTexture, Vector2 aTrashItemLocation, Rectangle aGameBoundaries): base(aTrashItemTexture, aTrashItemLocation, aGameBoundaries)
        {
            _trashItemLocation = aTrashItemLocation;
            _trashItemTexture = aTrashItemTexture;
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
            if (Location.Y > gameBoundaries.Height + 300)
            {
                Location.Y = _random.Next(-500, 0); 
                Location.X = _random.Next(0, (int)gameBoundaries.Width); 
            }
            if(_trashType == TrashType.Recycle && boundingBox.Intersects(aGameObjects.RecycleBin.boundingBox))
            {
                aGameObjects.Score.PlayerScore += 10; 
            }
            else if (_trashType == TrashType.Recycle && boundingBox.Intersects(aGameObjects.TrashBin.boundingBox))
            {
                aGameObjects.Score.PlayerScore -= 5; 
            }
            if (_trashType == TrashType.Trash && boundingBox.Intersects(aGameObjects.TrashBin.boundingBox))
            {
                aGameObjects.Score.PlayerScore += 10;
            }
            else if (_trashType == TrashType.Trash && boundingBox.Intersects(aGameObjects.RecycleBin.boundingBox))
            {
                aGameObjects.Score.PlayerScore -= 5;
            }
            else if (Velocity.Y == 0 && aGameObjects.RecycleBin.Velocity.X != 0)  //Change to Game Started.....
            {
                var newVelocity = new Vector2(0f, 4.5f);
                Velocity = newVelocity;
            }
            base.Update(aGameTime, aGameObjects);
        }

    }
}
