using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScene : MonoBehaviour
{
    public Button startButton;
    public Button howToPlayButton;
    public Button quitButton;
    public UnityEditor.SceneAsset gameScene;
    public UnityEditor.SceneAsset howToPlayScene;
   
    // Start is called before the first frame update
    void Start()
    {
        if (startButton != null)
            startButton.onClick.AddListener(StartGame);

        if (quitButton != null)
            quitButton.onClick.AddListener(QuitGame);

        if (howToPlayButton != null)
            howToPlayButton.onClick.AddListener(HowToPlay);
    }

    void StartGame()
    {

        string gameSceneString = gameScene.name;
        SceneManager.LoadScene(gameSceneString);
    }

    void HowToPlay()
    {

        string howToPlaySceneString = howToPlayScene.name;
        SceneManager.LoadScene(howToPlaySceneString);
    }

    void QuitGame()
    {
        Application.Quit();

        // This block is for Unity Editor to stop play mode
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif

    }
}
