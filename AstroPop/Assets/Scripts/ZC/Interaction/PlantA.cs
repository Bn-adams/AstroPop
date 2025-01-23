using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantA : MonoBehaviour, IInteractable
{
    public void InteractQ()
    {
        Debug.Log("Plant A says QQQQ!");
    }
    public void InteractE()
    {
        Debug.Log("Plant A says EEEE!");
    }
}
