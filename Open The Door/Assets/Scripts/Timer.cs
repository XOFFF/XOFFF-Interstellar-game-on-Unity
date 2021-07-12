using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    GameObject timer;
    [SerializeField]
    public float counter = 0f;
    bool gameIsStart;

    private void Start()
    {
        timer = GameObject.FindWithTag("Timer");
    }
    public void StartTimer()
    {
        gameIsStart = true;
    }

    public void StopTimer()
    {
        gameIsStart = false;
    }

    void Update()
    {
        if (gameIsStart == true)
        {
            counter += Time.deltaTime;
            timer.GetComponent<Text>().text = "Score: " + counter; //.ToString()
        }
    }
}
