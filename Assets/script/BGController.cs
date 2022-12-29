using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ChangSprite();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Sprite[] sprites;

    public SpriteRenderer bgImage;

    void ChangSprite()
    {
        if(bgImage != null && sprites != null && sprites.Length > 0)
        {
            int random = Random.Range(0, sprites.Length);

            if (sprites[random] != null)
            {
                bgImage.sprite = sprites[random];
            }
        }
    }
}
