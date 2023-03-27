using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Cat : MonoBehaviour
{    
    public GameObject loseMenu;
    public GameObject RestartButton;
    
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
    

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            Time.timeScale = 0;
            RestartButton.SetActive(true);
            loseMenu.SetActive(true);
        }
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }





}
 