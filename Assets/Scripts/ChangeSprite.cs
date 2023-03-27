using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    private Rigidbody2D rb;
    public Sprite sprite1;
    public Sprite sprite2;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        if(spriteRenderer == null)
        {
            spriteRenderer.sprite = sprite1;
        }
    }

    
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (spriteRenderer.sprite == sprite1 || collision.collider.tag == "Enemy")
        {
            spriteRenderer.sprite = sprite2;
        }
        else
        {
            spriteRenderer.sprite = sprite1;
        }
    }
}
