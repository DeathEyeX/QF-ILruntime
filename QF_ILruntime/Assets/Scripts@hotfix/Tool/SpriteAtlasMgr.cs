using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using QFramework.ILRuntime;

namespace BossCat {
    public class SpriteAtlasMgr 
    {
        public static Dictionary<string, UnityEngine.U2D.SpriteAtlas> atlasDic = new Dictionary<string, UnityEngine.U2D.SpriteAtlas>();
        public static ResLoader mResloader = ResLoader.Allocate();
        public static UnityEngine.U2D.SpriteAtlas GetAtlasWithKey(string atlasKey)
        {
            if (atlasDic.ContainsKey(atlasKey))
            {
                return atlasDic[atlasKey];
            }
            else
            {
                UnityEngine.U2D.SpriteAtlas spriteAtlas = mResloader.LoadSync<UnityEngine.U2D.SpriteAtlas>(atlasKey);
                if (spriteAtlas != null)
                {
                    atlasDic.Add(atlasKey, spriteAtlas);
                    return atlasDic[atlasKey];
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
