using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPUI : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public Sprite newSprite2;
    public Sprite newSprite3;
    void ChangeSprite()
    {
        spriteRenderer.sprite = newSprite;
    }

    void ChangesSprite()
    {
        spriteRenderer.sprite = newSprite2;
    }

    void ChangedSprite()
    {
        spriteRenderer.sprite = newSprite3;
    }



    // Update is called once per frame
    void Update()
    {
        if(health.currenthp == 3)
        {
            ChangeSprite();
        }
        else if (health.currenthp == 2)
        {
            ChangesSprite();
        }
        else if (health.currenthp == 1)
        {
            ChangedSprite();
        }
    }
}
