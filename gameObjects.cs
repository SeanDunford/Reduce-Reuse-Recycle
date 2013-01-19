using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReduceReuseRecycle
{
    public class gameObjects
    {
        public playerBin TrashBin {get; set;}
        public playerBin RecycleBin { get; set; }
        public Score Score { get; set; }
        public Icon Icon { get; set; }
        public List<trashItem> FallingItems{get; set;}
        
    }
}
