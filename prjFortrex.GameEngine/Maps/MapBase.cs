 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 using prjFortrex.GameEngine.GamePlay.Objects.Blocks;
 using prjFortrex.GameEngine.GamePlay.Objects.Entities;
 using prjFortrex.GameEngine.GamePlay.Objects.Items;

namespace prjFortrex.GameEngine.Maps
{
    abstract class MapBase
    {

        public List<ItemBase> ItemsList = new List<ItemBase>();
        public List<StructureBase> StructureList = new List<StructureBase>();
        public List<EntityBase> EntityList = new List<EntityBase>();
        




    }
}
