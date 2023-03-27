using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    [SerializeField] int score;
    [SerializeField] Text scoreText;
    void Start()
    {
        score = 0;
    }
  
    void Update()
    {
        scoreText.text = score.ToString();
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Score")
        {
            score++;
        }
    }
}
