using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NVS.Engine;
using NVS.Engine.GameObject;
using NVS.Engine.Interface;

namespace NVS.Core.GameObject;

public class PlayerStatus : IUpdate, IDraw
{
    private const float _MULTIPLIER_EXPIRY_TIME = 0.8f;
    private const int _MAX_MILTIPLIER = 20;
    private const Art _SPRITE_FONT = Art.FontDebug;
    private SpriteFont _font;

    private float _multiplierTimeLeft;
    private int _scoreForExtraLife;

    public int Lives { get; private set; }
    public int Score { get; private set; }
    public int Multiplier { get; private set; }


    public PlayerStatus() => Reset();

    public void Load(ArtHandler artHandler) => _font = artHandler.Fonts[_SPRITE_FONT];

    private void Reset()
    {
        Score = 0;
        Multiplier = 1;
        Lives = 4;
        _scoreForExtraLife = 2000;
        _multiplierTimeLeft = 0;
    }

    public void Update(GameTime gameTime)
    {
        if (Multiplier > 1)
        {
            if ((_multiplierTimeLeft -= (float)gameTime.ElapsedGameTime.TotalSeconds) <= 0)
            {
                _multiplierTimeLeft = _MULTIPLIER_EXPIRY_TIME;
                ResetMultiplier();
            }
        }
    }
    public void AddPoints(int basePoints)
    {
        if (PlayerShip.Instance.IsDead)
            return;
        Score += basePoints * Multiplier;
        while (Score >= _scoreForExtraLife)
        {
            _scoreForExtraLife += 2000;
            Lives++;
        }
    }
    public void IncreaseMultiplier()
    {
        if (PlayerShip.Instance.IsDead)
            return;
        _multiplierTimeLeft = _MULTIPLIER_EXPIRY_TIME;
        if (Multiplier < _MAX_MILTIPLIER)
            Multiplier++;
    }
    public void ResetMultiplier()
    {
        Multiplier = 1;
    }
    public void RemoveLife()
    {
        Lives--;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.DrawString(_font, $"Lives: {Lives}", new Vector2(5f), Color.White);
        Util.DrawRightAlignedString(_font, $"Score: {Score}", 5, (int)GameLoop.ScreenSize.X, spriteBatch);
        Util.DrawRightAlignedString(_font, $"Multiplier: {Multiplier}", 35, (int)GameLoop.ScreenSize.X, spriteBatch);
    }
}
