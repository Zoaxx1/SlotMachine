using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateSprites : MonoBehaviour, 
{
    public GameObject sprite;
    public float limitSprites;
    public Vector2 instantiatePosition;
    public float xInitialPosition;
    public List<float> yInitialPositions;
    public List<float> yInitialPositionsSave = new List<float>();
    private List<GameObject> spritesListInstantiates = new List<GameObject>();

    public List<GameObject> SpritesListInstantiates
    {
        get { return spritesListInstantiates; }
    }
    public void InstantiateSprite(bool start = false)
    {
        if (spritesListInstantiates.Count < limitSprites)
        {
            GameObject spriteInstantiate = Object.Instantiate(sprite, transform.position, transform.rotation);
            if(start)
            {
                spriteInstantiate.transform.position = new Vector2(xInitialPosition, yInitialPositionsSave[0]);
                yInitialPositionsSave.RemoveAt(0);
            }
            spriteInstantiate.SetActive(true);
            spritesListInstantiates.Add(spriteInstantiate);
        }
    }

    public void RemoveSprite(int i)
    {
        spritesListInstantiates.Remove(spritesListInstantiates[i]);
    }

    void Start()
    {
        yInitialPositionsSave = yInitialPositions;
        for (int i = 0; i < limitSprites; i++)
        {
            InstantiateSprite(true);
        }
    }


    // Update is called once per frame
    void Update()
    {
        InstantiateSprite();   
    }
}
