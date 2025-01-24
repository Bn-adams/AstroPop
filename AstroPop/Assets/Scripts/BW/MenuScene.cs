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
    
    public Scene GameScene;
    public Scene HowToPlay;

   
    // Start is called before the first frame update
    void Start()
    {
        if (startButton != null)
            startButton.onClick.AddListener(StartGame);

        if (quitButton != null)
            quitButton.onClick.AddListener(QuitGame);

        if (howToPlayButton != null)
            howToPlayButton.onClick.AddListener(HowToPlayScene);
    }

    void StartGame()
    {

        
        SceneManager.LoadScene(2);
    }

    void HowToPlayScene()
    {
        SceneManager.LoadScene(1);
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
