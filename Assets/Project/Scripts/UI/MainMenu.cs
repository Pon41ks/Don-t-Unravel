using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private RectTransform mainMenuHolder;
    [SerializeField] private ShopControl shop;

    private void Awake()
    {
        SaveData.Current = (SaveData)SaveSystem.Load(SaveSystem.Path);
        mainMenuHolder.gameObject.SetActive(true);
        shop.Initialize();
    }

    public void StartGame() //метод для начала игры 
    {
        SaveSystem.Save(SaveData.Current);
        SceneManager.LoadScene(1);
    }
    public void GoToShop() //метод для входа в магазин
    {
        mainMenuHolder.gameObject.SetActive(false);
        shop.Activate(true);
    }
    public void ReturnToMenu() //метод для выхода из магазина
    {
        mainMenuHolder.gameObject.SetActive(true);
        shop.Activate(false);
    }
    public void Exit()
    {
        Debug.Log("Вы вышли из игры!");
        Application.Quit();
    }
}