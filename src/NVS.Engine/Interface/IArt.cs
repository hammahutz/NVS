using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using NVS.Engine.Interface;


namespace NVS.Engine.Interface;

public interface IArt 
{
    public void Load(ContentManager content);
    public void Unload(ContentManager content);
}
