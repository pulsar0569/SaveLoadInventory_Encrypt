using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UIElements;
using System.Collections.Generic;

public class SaveLoadManager : MonoBehaviour
{
    string path;

    public void Start()
    {
        path = Application.persistentDataPath + "/inventorySave.dat";
    }

    public void Save()
    {

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, ItemManager.items);
        stream.Close();
        Debug.Log("Game Saved!");
    }

    public void Load()
    {
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            ItemManager.items = formatter.Deserialize(stream) as List<Item>;
            stream.Close();
            Debug.Log("Game Loaded!");
        }
        else
        {
            Debug.LogWarning("Save file not found.");
        }
    }
}
