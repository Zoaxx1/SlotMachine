using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sprites : MonoBehaviour
{
    public List<Sprite> spriteList;
    public float speed;
    private Rigidbody2D rb;

    public int GetRandomSpriteIndex(int minRange, int maxRange)
    {
        return Random.Range(minRange, maxRange);
    }
    public void SetSpriteRenderer()
    {
        int minRange = Random.Range(0, (spriteList.Count - 1) / 2);
        int maxRange = Random.Range(spriteList.Count / 2, spriteList.Count - 1);
        gameObject.GetComponent<SpriteRenderer>().sprite = spriteList[GetRandomSpriteIndex(minRange, maxRange)];
    }

    public void SpinSlices()
    {
        Debug.Log(gameObject.GetComponent<Rigidbody2D>() != null);
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, (transform.position.y + 5) * Time.deltaTime);
    }

    void Update()
    {
        SpinSlices();
    }
}
