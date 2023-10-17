using System.IO;
using UnityEngine;

public static class Save 
{
    public static void SaveToFile<T>(T datas, string fileName)
    {
        File.WriteAllText(Path.Combine(Application.persistentDataPath, fileName + ".json"), JsonUtility.ToJson(datas, true));
    }

    public static void LoadFromFile(object datas, string fileName)
    {
        string loadFile = File.ReadAllText(Path.Combine(Application.persistentDataPath, fileName + ".json"));
        JsonUtility.FromJsonOverwrite(loadFile, datas);
    }
}
