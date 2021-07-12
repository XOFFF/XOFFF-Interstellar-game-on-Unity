using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    Renderer rend;
    Color newColor;
    Color defaultColor;
    float addWhiteColor = 0.2f;
    void Start()
    {
        rend = GetComponent<Renderer>();
        defaultColor = rend.material.color;
        newColor = new Color(rend.material.color.r + addWhiteColor, rend.material.color.g + addWhiteColor, rend.material.color.b + addWhiteColor);
    }
    void OnMouseOver()
    {
        //Mouse is over GameObject
        rend.material.SetColor("_Color", newColor);
    }

    void OnMouseExit()
    {
        //Mouse is out of GameObject
        rend.material.SetColor("_Color", defaultColor);
    }
}
