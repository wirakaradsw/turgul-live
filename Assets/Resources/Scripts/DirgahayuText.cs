using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirgahayuText : MonoBehaviour
{
    public TextMesh dirgahayuTxt;

    void Start()
    {
        int yearNow = System.DateTime.Now.Year;
        int dirgahayu = yearNow - 1945;
        dirgahayuTxt.text = dirgahayu.ToString();
    }

}
