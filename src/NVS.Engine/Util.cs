using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace NVS.Engine;

public static class Util
{
    #region Extensios methods

    public static float ToAngle(this Vector2 vector) => MathF.Atan2(vector.Y, vector.X);
    public static Vector2 ToAngle(this float angle) => new Vector2(MathF.Cos(angle), MathF.Sin(angle));
    public static float NextFloat(this Random rnd, float minValue, float maxValue) => (float)rnd.NextDouble() * (maxValue - minValue) + minValue;

    #endregion

    #region Math Util

    public static Vector2 FromPolar(float angle, float magnitude) => magnitude * new Vector2(MathF.Cos(angle), MathF.Sin(angle));

    #endregion

}
