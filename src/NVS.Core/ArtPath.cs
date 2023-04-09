using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NVS.Core;

public static class ArtPath
{
    public static readonly Dictionary<Art, string> Paths = new Dictionary<Art, string>()
    {
        {Art.GFXPlayer, "GFX/Player"},
        {Art.GFXBlackHole, "GFX/Black Hole"},
        {Art.GFXBullet,"GFX/Bullet"},
        {Art.GFXGlow,"GFX/Glow"},
        {Art.GFXLaser,"GFX/Laser"},
        {Art.GFXPointer,"GFX/Pointer"},
        {Art.GFXSeeker,"GFX/Seeker"},
        {Art.GFXWanderer,"GFX/Wanderer"},

        {Art.Music,"SFX/Music/Music"},

        {Art.SFXExplosion1,"SFX/Sound/explosion-01"},
        {Art.SFXExplosion2,"SFX/Sound/explosion-02"},
        {Art.SFXExplosion3,"SFX/Sound/explosion-03"},
        {Art.SFXExplosion4,"SFX/Sound/explosion-04"},
        {Art.SFXExplosion5,"SFX/Sound/explosion-05"},
        {Art.SFXExplosion6,"SFX/Sound/explosion-06"},
        {Art.SFXExplosion7,"SFX/Sound/explosion-07"},
        {Art.SFXExplosion8,"SFX/Sound/explosion-08"},
        {Art.SFXShoot1,"SFX/Sound/shoot-01"},
        {Art.SFXShoot2,"SFX/Sound/shoot-02"},
        {Art.SFXShoot3,"SFX/Sound/shoot-03"},
        {Art.SFXShoot4,"SFX/Sound/shoot-04"},
        {Art.SFXSpawn1,"SFX/Sound/spawn-01"},
        {Art.SFXSpawn2,"SFX/Sound/spawn-02"},
        {Art.SFXSpawn3,"SFX/Sound/spawn-03"},
        {Art.SFXSpawn4,"SFX/Sound/spawn-04"},
        {Art.SFXSpawn5,"/Sound/spawn-05"},
        {Art.SFXSpawn6,"SFX/Sound/spawn-06"},
        {Art.SFXSpawn7,"SFX/Sound/spawn-07"},
        {Art.SFXSpawn8,"SFX/Sound/spawn-08"},

        {Art.FontDebug, "Font/Debug"},
    };
}