using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button loadButton;
    public string gameScene;
    public static bool LoadSave = false;

    void Start()
    {
        string filePath = Application.persistentDataPath + "/savegame.json";

        if (!File.Exists(filePath))
        {
            loadButton.interactable = false;
        }

    }

    public void NewButton()
    {
        LoadSave = false;
        SceneManager.LoadScene(gameScene);



    }

    public void LoadButton()
    {
        LoadSave = true;
        SceneManager.LoadScene(gameScene);
    }





}
