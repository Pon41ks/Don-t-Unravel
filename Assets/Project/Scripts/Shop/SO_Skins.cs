using UnityEngine;

[CreateAssetMenu(fileName = "NewSkinsDatabase", menuName = "Data/SkinsDatabase")]
public class SO_Skins : ScriptableObject
{
    public SkinParameters[] skinsParameters;
}
[System.Serializable]
public class SkinParameters
{
    public Sprite skinSprite;
    public Sprite deadSkinSprite;
    public int skinPrice;
}