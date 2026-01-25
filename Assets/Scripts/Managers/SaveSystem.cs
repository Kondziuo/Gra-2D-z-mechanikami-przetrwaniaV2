using UnityEngine;
using System.IO;
using UnityEngine.InputSystem;
public class SaveSystem : MonoBehaviour
{
    public Inventory inventory;
    public GameObject mapContainer;

    string savePath;

    void Awake()
    {
        savePath = Application.persistentDataPath + "/savegame.json";
    }


    void Update()
    {
        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            SaveGame();
        }
    }

    public void SaveGame()
    {
        SaveData data = new SaveData();

        foreach (ResourceType type in System.Enum.GetValues(typeof(ResourceType)))
        {
            data.resourceName.Add(type.ToString());
            data.resourceAmount.Add(inventory.Get(type));
        }

        foreach (Transform obj in mapContainer.transform) 
        { 
        data.objectType.Add(obj.name);
        data.objectPosition.Add(obj.position);  
        }

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);

        Debug.Log("gra zapisana" + savePath);

    }



}
