using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCanvas : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject infoCanvas;

    private void Awake()
    {
        GlobalEventManager.OnPlayerDied.AddListener(ShowGameOverPanel);
    }
    private void ShowGameOverPanel()
    {
        Time.timeScale = 0;
        infoCanvas.SetActive(false);
        gameOverPanel.SetActive(true);
    }
    public void RestartLevel()
    {       
        SceneManager.LoadScene(1);        
    }
    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}