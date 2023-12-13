using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class SpritesPlayModeTest
{
    GameObject spritesGO;
    Sprites sprites;
    string spriteName;

    [SetUp]
    public void SetUp()
    {
        GameObject prefab = Resources.Load<GameObject>("Sprites/CandiesSprite/sprites/candy_1");
        spritesGO = prefab;
        sprites = spritesGO.AddComponent<Sprites>();
        var sprite = Resources.Load<GameObject>("Sprites/CandiesSprite/sprites/candy_2").GetComponent<SpriteRenderer>().sprite;
        spriteName = sprite.name;
        sprites.spriteList = new List<Sprite>()
        {
            sprite, sprite, sprite, sprite, sprite, sprite
        };
    }


    [UnityTest]
    public IEnumerator Set_Random_Image_In_Sprite()
    {
        yield return null;
        sprites.SetSpriteRenderer();
        
        Assert.AreEqual(spriteName, spritesGO.GetComponent<SpriteRenderer>().sprite.name);
    }
}
