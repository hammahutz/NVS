using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using NVS.Engine.Interface;

namespace NVS.Engine.Art;

public abstract class ArtManager
{
    public ContentManager Content { get; private set; }
    public ArtManager(ContentManager content) => Content = content;

    public abstract void Load();
    public void Unload() => Content.Unload();
    public void Unload(string assetName) => Content.UnloadAsset(assetName);
    public void Unload(IList<string> assetName) => Content.UnloadAssets(assetName);

}
