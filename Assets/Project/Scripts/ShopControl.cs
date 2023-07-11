using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Data.SqlTypes;
using TMPro;

public class ShopControl : ScoreManager
{
    public int isBallSold;
    public int moneyAmount()
    {
        return _coin;
    }
    public TextMeshProUGUI moneyAmountText;
    public TextMeshProUGUI ballPrice;
    public Button buyButton;


   

    // Update is called once per frame
    void Update()
    {
        moneyAmountText.text = "Money: " + _coin.ToString() + "$";
        isBallSold = PlayerPrefs.GetInt("isBallSold");
        if (_coin>= 10 && isBallSold == 0)
        {
            buyButton.interactable = true;
        }
        else
        {
            buyButton.interactable = false;
        }

        
    }

    public void BuyBall()
    {
        _coin -= 10;
        PlayerPrefs.SetInt("isBallSold", 1);
        ballPrice.text = "sold!";
        buyButton.gameObject.SetActive(false);
    }

    public void ToMenu()
    {
        PlayerPrefs.SetInt("_coin", _coin);
        SceneManager.LoadScene("Game");
    }
}
