using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Skin : MonoBehaviour
{
    public int SkinPrice { get; private set; }
    public string SkinName { get; private set; }
    [Header("References")]
    [SerializeField] private Image skinImage;
    [SerializeField] private TextMeshProUGUI skinNameText;
    [SerializeField] private TextMeshProUGUI skinPriceText;
    [SerializeField] private Button buyButton;
    [SerializeField] private TextMeshProUGUI buyButtonText;
    private bool _isSold;
    private bool _isEquipped;

    public void Initialize(int price, Sprite skin)
    {
        skinImage.sprite = skin;
        SkinPrice = price;
        SkinName = skinImage.sprite.name;
        skinNameText.text = SkinName;
        UpdateUI();
    }
    public void Refresh()
    {
        UpdateUI();
    }
    private void UpdateUI()
    {
        if (SaveData.Current.collectedSkins.Contains(SkinName))
        {
            _isSold = true;
            _isEquipped = SaveData.Current.equippedSkin == SkinName;
        }
        switch (_isSold)
        {
            case true when !_isEquipped:
                buyButton.interactable = true;
                skinPriceText.text = "Collected";
                buyButtonText.text = "Equip";
                break;
            case true when _isEquipped:
                buyButton.interactable = false;
                skinPriceText.text = "Collected";
                buyButtonText.text = "Equipped";
                break;
            case false when SaveData.Current.coins >= SkinPrice:
                buyButton.interactable = true;
                skinPriceText.text = "Price: " + SkinPrice;
                buyButtonText.text = "Buy";
                break;
            case false when SaveData.Current.coins < SkinPrice:
                buyButton.interactable = false;
                skinPriceText.text = "Price: " + SkinPrice;
                buyButtonText.text = "Not enough coins";
                break;
        }
    }
    public void BuyOrEquipSkin()
    {
        if (SaveData.Current.coins >= SkinPrice && !_isSold)
        {
            BuySkin();
        }
        if (_isSold && !_isEquipped)
        {
            EquipSkin();
        }
        UpdateUI();
    }
    public void SetDefaultSkin()
    {
        _isSold = true;
        _isEquipped = true;
        SaveData.Current.collectedSkins.Add(SkinName);
        SaveData.Current.equippedSkin = SkinName;
        GlobalEventManager.SendUpdateShop();
    }
    private void BuySkin()
    {
        SaveData.Current.coins -= SkinPrice;
        _isSold = true;
        SaveData.Current.collectedSkins.Add(SkinName);
        GlobalEventManager.SendUpdateShop();
    }
    private void EquipSkin()
    {
        _isEquipped = true;
        SaveData.Current.equippedSkin = SkinName;
        GlobalEventManager.SendUpdateShop();
    }
}