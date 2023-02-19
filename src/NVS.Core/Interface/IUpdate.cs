using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace NVS.Core;

public interface IUpdate
{
    public abstract void Update(GameTime gameTime);
}
