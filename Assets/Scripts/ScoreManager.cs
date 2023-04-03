using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int coin;
    
    [SerializeField] private TextMeshProUGUI coinText;
    private void Awake()
    {
        coin = PlayerPrefs.GetInt("maxCoin", 0);
        coinText.text = PlayerPrefs.GetInt("maxCoin").ToString();
        EventManager.OnCoinColected.AddListener(Refresh);
    }
    private void Refresh()
    {
      coin++;   
      PlayerPrefs.SetInt("maxCoin", coin);
      coinText.text = PlayerPrefs.GetInt("maxCoin").ToString();
    
    }
}
