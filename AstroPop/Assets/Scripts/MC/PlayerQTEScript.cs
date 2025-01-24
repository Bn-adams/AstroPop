using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerQTEScript : MonoBehaviour
{
    public GameObject QTEGameObject;
    public GameObject QTESlider;
    // Start is called before the first frame update
    void Start()
    {
        QTESlider.SetActive(false);
        QTEGameObject.SetActive(false);
    }

    private void QTESliderOn()
    {
        QTEGameObject.SetActive(true);
        QTESlider.SetActive(true);
    }

    private void QTESliderOff()
    {
        QTESlider.SetActive(false);
        QTEGameObject.SetActive(false);
    }

    public void LostGame()
    {
        QTESliderOff();
    }

    public void WonGame()
    {
        QTESliderOff();
    }

    public void StartGame()
    {
        QTESliderOn();
    }
}
