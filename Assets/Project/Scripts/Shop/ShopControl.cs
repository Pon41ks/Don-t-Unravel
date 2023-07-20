using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopControl : MonoBehaviour
{
    [SerializeField] private RectTransform skinPanelsHolder;
    [SerializeField] private Skin skinPanelPrefab;
    [SerializeField] private TextMeshProUGUI coinsAmountText;
    [SerializeField] private SO_Skins skinsDatabase;
    
    [SerializeField] private RectTransform shopHolder;
    
    public List<Skin> skinsPanels;
    public void Initialize()
    {
        SaveData.Current.collectedSkins ??= new List<string>();
        GlobalEventManager.OnShopUpdated.AddListener(Refresh);
        
        Activate(false);
        
        foreach (var skinParameters in skinsDatabase.skinsParameters)
        {
            var skin = Instantiate(skinPanelPrefab, skinPanelsHolder);
            skin.Initialize(skinParameters.skinPrice, skinParameters.skinSprite);
            if (skin.SkinPrice == 0 && SaveData.Current.equippedSkin == "")
            {
                skin.SetDefaultSkin();
            }
            skinsPanels.Add(skin);
        }
        Refresh();
    }
    private void Refresh()
    {
        coinsAmountText.text = "Coins: " + SaveData.Current.coins;
        foreach (var skin in skinsPanels)
        {
            skin.Refresh();
        }
        SaveSystem.Save(SaveData.Current);
    }
    public void Activate(bool value)
    {
        shopHolder.gameObject.SetActive(value);
        Refresh();
    }
    public void AddCoins(int count)
    {
        SaveData.Current.coins += count;
        Refresh();
    }
}