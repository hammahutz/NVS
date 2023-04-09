using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace NVS.Engine;

public static class Util
{
    public static float ToAngle(this Vector2 vector) => MathF.Atan2(vector.Y, vector.X);
}
