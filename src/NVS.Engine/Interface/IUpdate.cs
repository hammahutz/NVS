using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace NVS.Engine.Interface;

public interface IUpdate
{
    public abstract void Update(GameTime gameTime);
}
