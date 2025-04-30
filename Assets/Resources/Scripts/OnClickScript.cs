using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickScript : MonoBehaviour
{
    public PatrickScript patrick;

    void OnMouseDown()
    {
        //Debug.Log("Sprite Clicked");
        patrick.OnMouseDown();
    }
}
