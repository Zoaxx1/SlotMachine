using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class InstantiateSpritesPlayModeTest
{
    GameObject instantiateSpritesGO;
    InstantiateSprites instantiateSprites;
    List<GameObject> spritesList;
    int limitSprites = 6;
    float xInitialPosition = 0f;
    List<float> yInitialPositions;

    [SetUp]
    public void SetUp()
    {
        instantiateSpritesGO = new GameObject();
        instantiateSprites = instantiateSpritesGO.AddComponent<InstantiateSprites>();
        GameObject sprite = new GameObject();
        sprite.SetActive(false);
        yInitialPositions = new List<float>()
        {
            1f,2f,3f,4f,5f,6f
        };
        instantiateSprites.sprite = sprite;
        instantiateSprites.limitSprites = limitSprites;
        instantiateSprites.xInitialPosition = xInitialPosition;
        instantiateSprites.yInitialPositions = yInitialPositions;
    }

    [UnityTest]
    public IEnumerator Start_Instantiate_Sprites()
    {
        yield return null;
        Assert.AreEqual(limitSprites, instantiateSprites.SpritesListInstantiates.Count);
    }

    [UnityTest]
    public IEnumerator Start_Sprite_Instantiate_Are_Active()
    {
        yield return null;
        Assert.IsTrue(instantiateSprites.SpritesListInstantiates[3].activeSelf);
    }

    [UnityTest]
    public IEnumerator Start_Instantiate_Sprites_Initial_Position()
    {
        yield return null;
        Vector3 initialPosition = new Vector2(xInitialPosition, 1f);
        Assert.AreEqual(instantiateSprites.SpritesListInstantiates[0].transform.position, initialPosition);
    }

    [UnityTest]
    public IEnumerator Update_Instantiate_Sprites()
    {
        instantiateSprites.RemoveSprite(2);
        yield return new WaitForSeconds(2);
        Assert.AreEqual(limitSprites, instantiateSprites.SpritesListInstantiates.Count);
    }
}
