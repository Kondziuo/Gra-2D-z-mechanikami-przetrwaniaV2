using UnityEngine;
using System.IO;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class SaveSystem : MonoBehaviour
{
    public Inventory inventory;
    public GameObject mapContainer;
    public List<GameObject> prefabs; 
    string savePath;

    void Awake()
    {
        savePath = Application.persistentDataPath + "/savegame.json";
    }

    void Start()
    {
     
        if (MainMenu.LoadSave)
        {
            LoadGame();
            MainMenu.LoadSave = false; 
        }
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
            string cleanName = obj.name.Replace("(Clone)", "").Trim();
            data.objectType.Add(cleanName);
            data.objectPosition.Add(obj.position);
        }

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);
    }

    public void LoadGame()
    {
        if (!File.Exists(savePath)) return;

        string json = File.ReadAllText(savePath);
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        foreach (Transform child in mapContainer.transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < data.objectType.Count; i++)
        {
            string nameFromSave = data.objectType[i];
            Vector3 posFromSave = data.objectPosition[i];

            GameObject prefabToSpawn = prefabs.Find(p => p.name == nameFromSave);

            if (prefabToSpawn != null)
            {
                Instantiate(prefabToSpawn, posFromSave, Quaternion.identity, mapContainer.transform);
            }
            else
            {
                Debug.LogWarning("Nie znaleziono prefaba o nazwie: " + nameFromSave);
            }
        }



    }
}