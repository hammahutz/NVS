using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using NVS.Engine.Interface;


namespace NVS.Engine.Art;

public abstract class ArtAsset 
{
    public abstract void Load(ContentManager content);
}
