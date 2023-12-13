using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class SpritesEditModeTest
{
    GameObject spritesGO = new GameObject();
    Sprites sprites;
    Sprite sprite;

    [SetUp]
    public void SetUp()
    {
        spritesGO.AddComponent<SpriteRenderer>();
        spritesGO.AddComponent<Rigidbody2D>();
        sprites = spritesGO.AddComponent<Sprites>();
        sprites.spriteList = new List<Sprite>()
        {
            sprite, sprite, sprite, sprite, sprite, sprite
        };
    }

    [TestCase(1, 4)]
    [TestCase(2, 3)]
    [TestCase(0, 5)]
    [TestCase(4, 6)]
    public void Get_Random_Index_To_Sprite_List(int minRange, int maxRange)
    {
        int randomImageIndex = sprites.GetRandomSpriteIndex(minRange,maxRange);
        Assert.IsTrue(randomImageIndex >= minRange && randomImageIndex <= maxRange);
    }

    [Test]
    public void Accelerate_Sprite()
    {
        sprites.speed = 5f;
        spritesGO.transform.position = Vector2.zero;
        sprites.SpinSlices();
        Assert.AreEqual(new Vector3(0, 5, 0), spritesGO.transform.position);
    }
}
