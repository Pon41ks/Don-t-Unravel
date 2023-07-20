using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static readonly string Path = Application.persistentDataPath + "/saves/Save.save";
    public static void Save(object saveData)
    {
        BinaryFormatter formatter = GetBinaryFormatter();

        if (!Directory.Exists(Application.persistentDataPath + "/saves"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/saves");
        }


        FileStream fileStream = File.Create(Path);
        
        formatter.Serialize(fileStream, saveData);
        
        fileStream.Close();
    }
    public static object Load(string path)
    {
        if (!File.Exists(path))
        {
            return null;
        }

        BinaryFormatter formatter = GetBinaryFormatter();
        
        FileStream fileStream = File.Open(path, FileMode.Open);

        try
        {
            object save = formatter.Deserialize(fileStream);
            fileStream.Close();
            return save;
        }
        catch
        {
            Debug.LogErrorFormat("Failed to load file at {0}", path);
            fileStream.Close();
            return null;
        }
    }
    private static BinaryFormatter GetBinaryFormatter()
    {
        BinaryFormatter formatter = new BinaryFormatter();

        return formatter;
    }
}