using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class InstantiateSpritesEditModeTests
{
    GameObject instantiateSpritesGO = new GameObject();
    GameObject sprite = new GameObject();
    InstantiateSprites instantiateSprites;
    int limitSprites = 6;
    Vector2 instatiatePosition = new Vector2(2, 2);

    [SetUp]
    public void SetUp()
    {
        instantiateSprites = instantiateSpritesGO.AddComponent<InstantiateSprites>();
        instantiateSprites.sprite = sprite;
        instantiateSprites.limitSprites = limitSprites;
        instantiateSprites.instantiatePosition = instatiatePosition;
    }

    private void CallMultipleInstantiateSprites(int calls)
    {
        for (int i = 0; i < calls; i++)
        {
            instantiateSprites.InstantiateSprite();
        }
    }

    [Test]
    public void Instantiate_Sprites()
    {
        CallMultipleInstantiateSprites(2);
        Assert.AreEqual(2, instantiateSprites.SpritesListInstantiates.Count);
    }

    [Test]
    public void Instantiate_Sprite_Whith_Limit_Active()
    {
        CallMultipleInstantiateSprites(7);
        Assert.AreEqual(6, instantiateSprites.SpritesListInstantiates.Count);
    }

    [Test]
    public void Remove_Sprite()
    {
        instantiateSprites.InstantiateSprite();
        instantiateSprites.RemoveSprite(0);
        Assert.AreEqual(0, instantiateSprites.SpritesListInstantiates.Count);
    }

    [TestCase(0)]
    [TestCase(4)]
    [TestCase(2)]
    public void Remove_Specific_Sprite(int i)
    {
        CallMultipleInstantiateSprites(6);
        instantiateSprites.RemoveSprite(i);
        Assert.AreEqual(5, instantiateSprites.SpritesListInstantiates.Count);
    }

    [TestCase(0)]
    [TestCase(4)]
    [TestCase(2)]
    public void Remove_Instantiate_And_NotInstantiate(int i)
    {
        CallMultipleInstantiateSprites(6);
        instantiateSprites.RemoveSprite(i);
        Assert.AreEqual(5, instantiateSprites.SpritesListInstantiates.Count);
        instantiateSprites.InstantiateSprite();
        Assert.AreEqual(6, instantiateSprites.SpritesListInstantiates.Count);
        instantiateSprites.InstantiateSprite();
        Assert.AreEqual(6, instantiateSprites.SpritesListInstantiates.Count);
    }
}
