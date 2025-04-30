using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GletserTrainingScript : MonoBehaviour
{
    public TrainingScript manager;

    void OnMouseDown()
    {
        manager.OnChatWithGletser();
    }
}
