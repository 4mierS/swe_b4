using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;

    private void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        startButton = root.Q<Button>("play");
        exitButton = root.Q<Button>("exit");

        startButton.clicked += LoadLevelauswahl;
        exitButton.clicked += ExitGame;

    }

    public void LoadLevelauswahl()
    {
        Debug.Log("Loading levelauswahl");
        SceneManager.LoadScene("Levelauswahl");
    }

    public void ExitGame()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }
}
