using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NVS.Engine;

public static class Util
{
    #region Extensios methods

    public static float ToAngle(this Vector2 vector) => MathF.Atan2(vector.Y, vector.X);
    public static Vector2 ToAngle(this float angle) => new Vector2(MathF.Cos(angle), MathF.Sin(angle));
    public static float NextFloat(this Random rnd, float minValue, float maxValue) => (float)rnd.NextDouble() * (maxValue - minValue) + minValue;
    public static Vector2 ScaleTo(this Vector2 vector, float length) => vector * (length / vector.Length());

    #endregion

    #region Math Util

    public static Vector2 FromPolar(float angle, float magnitude) => magnitude * new Vector2(MathF.Cos(angle), MathF.Sin(angle));

    #endregion

    #region Monogame helpers
    public static void DrawRightAlignedString(SpriteFont spriteFont, string text, float yPosition, int screenWidth, SpriteBatch spriteBatch) => spriteBatch.DrawString
        (
            spriteFont,
            text,
            new Vector2(screenWidth - spriteFont.MeasureString(text).X - 5, yPosition),
            Color.White
        );
    #endregion

}
