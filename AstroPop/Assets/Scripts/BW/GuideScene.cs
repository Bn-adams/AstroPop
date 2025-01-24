using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GuideScene : MonoBehaviour
{
    public Button quitButton;
    
   
   
    // Start is called before the first frame update
    void Start()
    {
      if (quitButton != null)
         {
            quitButton.onClick.AddListener(GoBack);
         }
            
    }

    void GoBack()
    {
        
        SceneManager.LoadScene(0);
    }
}
