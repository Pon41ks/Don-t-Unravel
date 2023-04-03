using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    private  int score;
    [SerializeField] Text scoreText;
    [SerializeField] Text finalScoreText;
    [SerializeField] Text recordText;
    private int record;
    
    void Start()
    {
        score = 0;
               
    }
  
    void Update()
    {
        record = score;
        
        if(record > PlayerPrefs.GetInt("record"))
        {
            PlayerPrefs.SetInt("record", record);
        }
        scoreText.text = score.ToString();
        recordText.text = "–екорд:" + PlayerPrefs.GetInt("record");
        finalScoreText.text = "»тоговый —чет:" + score.ToString();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Score")
        {
            score++;
        }
    }
}
