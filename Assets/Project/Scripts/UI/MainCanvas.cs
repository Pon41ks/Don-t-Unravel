using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCanvas : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject infoCanvas;
    [SerializeField] private Player player;
    private void Awake()
    {
        SaveData.Current = (SaveData)SaveSystem.Load(SaveSystem.Path);
        GlobalEventManager.OnPlayerDied.AddListener(ShowGameOverPanel);
        Time.timeScale = 1; 
        player.Initialize();
    }
    private void ShowGameOverPanel()
    {
        Time.timeScale = 0;
        infoCanvas.SetActive(false);
        gameOverPanel.SetActive(true);
    }
    public void RestartLevel()
    {       
        SaveSystem.Save(SaveData.Current);
        SceneManager.LoadScene(1);        
    }
    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SaveSystem.Save(SaveData.Current);
        SceneManager.LoadScene(0);
    }
}