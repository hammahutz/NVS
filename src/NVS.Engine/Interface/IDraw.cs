using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace NVS.Engine.Interface;

public interface IDraw
{
    public void Draw(SpriteBatch spriteBatch);
}
