using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickObjectLogic : MonoBehaviour
{
    string objectName;
    public CanvasManager canvasManager;

    void Start()
    {
        objectName = transform.tag;
    }
    void OnMouseDown()
    {
        canvasManager.CheckCondition(objectName);
    }
}
