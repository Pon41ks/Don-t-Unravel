using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    protected int _coin;
    private int _score;
    private int _record;
    
    [SerializeField] private TextMeshProUGUI coinText;
    
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private TextMeshProUGUI recordText;
    private void Awake()
    {
        _coin = PlayerPrefs.GetInt("maxCoin", 0);
        coinText.text = PlayerPrefs.GetInt("maxCoin").ToString();
        
        RefreshScore();
        GlobalEventManager.OnScoreAdded.AddListener(AddScore);
        GlobalEventManager.OnCoinCollected.AddListener(RefreshCoins);
    }
    private void RefreshCoins()
    {
        _coin++;   
        PlayerPrefs.SetInt("maxCoin", _coin);
        coinText.text = PlayerPrefs.GetInt("maxCoin").ToString();
    }
    private void AddScore(int value)
    {
        _score += value;
        RefreshScore();
    }
    private void RefreshScore()
    {
        _record = _score;
        if(_record > PlayerPrefs.GetInt("record"))
        {
            PlayerPrefs.SetInt("record", _record);
        }
        scoreText.text = _score.ToString();
        recordText.text = "Рекорд:" + PlayerPrefs.GetInt("record");
        finalScoreText.text = "Итоговый Счет:" + _score;
    }
}