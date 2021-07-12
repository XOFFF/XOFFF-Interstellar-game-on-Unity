using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPosition : MonoBehaviour
{
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        transform.Rotate(45f, transform.rotation.y, transform.rotation.z, Space.Self);
    }
}
