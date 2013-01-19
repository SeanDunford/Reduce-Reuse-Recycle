using SharpDX;
using SharpDX.Direct3D11;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReduceReuseRecycle
{
    public class Player : Sprite
    {
        private playerBin _TrashBin;
        private playerBin _ReycleBin;

        public Player(Texture2D aTexture, Vector2 aLocation, Rectangle aGameBoundaries)
        {
            this._texture = aTexture;
            this.Location = aLocation;
            this.Velocity = Vector2.Zero;
            this.gameBoundaries = aGameBoundaries; 
 
            
        }

        public Player(playerBin aTrashBin, playerBin aRecycleBin)
        {
            _TrashBin = aTrashBin;
            _ReycleBin = aRecycleBin; 
        }
        
    }


}
