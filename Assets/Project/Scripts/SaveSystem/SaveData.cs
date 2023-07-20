using System.Collections.Generic;

[System.Serializable]
public class SaveData
{
    private static SaveData _current;

    public static SaveData Current
    {
        get => _current ??= new SaveData();
        set
        {
            if(value != null)
            {
                _current = value;
            }
        }
    }
    public int coins;
    public int record;
    public List<string> collectedSkins;

    public string equippedSkin;
}