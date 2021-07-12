using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : MonoBehaviour
{
    public GameObject startPanel;
    public PlayerMovements movements;

    public Text highScore;
    void Start()
    {
        DisableMovements();

        startPanel.SetActive(true);
        if (PlayerPrefs.GetFloat("highScore") > 0f)
            highScore.text = PlayerPrefs.GetFloat("highScore").ToString();
        else
            PlayerPrefs.SetFloat("highScore", 0f);
    }
    public void StartPlay()
    {
        EnableMovements();

        startPanel.SetActive(false);
    }

    public void DisableMovements()
    {
        movements.enabled = false;
    }

    public void EnableMovements()
    {
        movements.enabled = true;
    }
}
