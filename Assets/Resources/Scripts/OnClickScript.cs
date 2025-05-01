using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnClickScript : MonoBehaviour, IPointerDownHandler
{
    public PatrickScript patrick;

    void OnMouseDown()
    {
        //Debug.Log("Sprite Clicked");
        patrick.OnMouseDown();
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        OnMouseDown();
    }
}
