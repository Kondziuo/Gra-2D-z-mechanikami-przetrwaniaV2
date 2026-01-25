using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button loadButton;
    public string gameScene;


    void Start()
    {
        string filePath = Application.persistentDataPath + "/ savegame.json";

        if (!File.Exists(filePath))
        {
        loadButton.interactable = false
        }

    }

    void NewGame()
    {

    }

    void LoadGame()
    {

    }





}
