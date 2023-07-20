using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int _collectedCoins;
    private int _score;

    [SerializeField] private TextMeshProUGUI coinText;
    
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private TextMeshProUGUI recordText;
    [SerializeField] private TextMeshProUGUI collectedCoinsText;
    private void Awake()
    {
        coinText.text = SaveData.Current.coins.ToString();
        
        GlobalEventManager.OnScoreAdded.AddListener(AddScore);
        GlobalEventManager.OnCoinCollected.AddListener(AddCoin);
        GlobalEventManager.OnPlayerDied.AddListener(UpdateGameOverPanel);
    }
    private void AddCoin()
    {
        SaveData.Current.coins++;
        _collectedCoins++;
        coinText.text = SaveData.Current.coins.ToString();
    }
    private void AddScore(int value)
    {
        _score += value;
        scoreText.text = _score.ToString();
    }
    private void UpdateGameOverPanel()
    {
        if(_score > SaveData.Current.record)
        {
            SaveData.Current.record = _score;
        }
        scoreText.text = _score.ToString();
        recordText.text = "Рекорд:" + SaveData.Current.record;
        finalScoreText.text = "Набрано очков:" + _score;
        collectedCoinsText.text = "Собрано монет:" + _collectedCoins;
    }
}