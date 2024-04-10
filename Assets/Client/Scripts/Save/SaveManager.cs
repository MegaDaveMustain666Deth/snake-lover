using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class SaveManager : PersistentSingleton<SaveManager>
{
    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        string filePath = Application.persistentDataPath + "/savegame";
        FileStream fs = new FileStream(filePath, FileMode.Create);

        DataSave.Save save = new DataSave.Save();
        bf.Serialize(fs, save);
        fs.Close();
    }

    public DataSave.Save loadGameData()
    {
        string filePath = Application.persistentDataPath + "/savegame.save";
        if (!File.Exists(filePath)) return null;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(filePath, FileMode.Open);
        DataSave.Save save = bf.Deserialize(fs) as DataSave.Save;

        fs.Close();
        return save;
    }
}
