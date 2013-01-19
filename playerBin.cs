using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReduceReuseRecycle
{
    public class playerBin
    {
        Texture _trashBinTexture;
        Vector2 _trashBinLocation; 
        Rectangle _gameBoundaries;
        binType _binType; 
 

        playerBin(Texture aTrashBinTexture, Vector2 aTrashBinLocation, Rectangle aGameBoundaries, binType aBinType)//: this(a = _a; ???)
        {
            _trashBinLocation = aTrashBinLocation;
            _trashBinTexture = aTrashBinTexture;
            _gameBoundaries = aGameBoundaries;
            _binType = aBinType; 
        } 

    }
   
}
