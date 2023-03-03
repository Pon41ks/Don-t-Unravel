using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cat : MonoBehaviour
{
    [SerializeField] GameObject RestartButton; // Игровой объект отвечающий за перезапуск уровня
    [SerializeField] float force; //сила толчка
    Rigidbody2D rb; 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Time.timeScale = 1; 
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * force;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy" )
        {
            Destroy(gameObject);
            Time.timeScale = 0;
            RestartButton.SetActive(true);
        }
    }



}
 