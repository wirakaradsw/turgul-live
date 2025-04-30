using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GletserTrainingScript : MonoBehaviour, IPointerDownHandler
{
    public TrainingScript manager;

    void OnMouseDown()
    {
        manager.OnChatWithGletser();
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        OnMouseDown();
    }
}
