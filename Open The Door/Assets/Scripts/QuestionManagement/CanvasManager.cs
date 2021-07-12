using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField]
    public AnimationLogic chest;
    [SerializeField]
    public AnimationLogic door;
    public GameObject key;
    bool isChestOpen;
    bool doHaveKey;

    public GameObject questionPanel;
    public GameObject gameOverPanel;

    public Text bestScoreUI;
    public Text currentScoreUI;
    public Timer timer;

    public Text headerText;
    public Button firstButton;
    public Button secondButton;

    public StartPanel movements;
    public RandomPositions random;

    public void CheckCondition(string objectName)
    {
        switch (objectName)
        {
            case "Chest":
                if (isChestOpen == false)
                    questionPanel.SetActive(true);

                headerText.text = "Open Chest?";
                firstButton.GetComponentInChildren<Text>().text = "Yes";
                secondButton.GetComponentInChildren<Text>().text = "No";
                secondButton.gameObject.SetActive(true);

                movements.DisableMovements();
                break;

            case "Key":
                headerText.text = "Take Key?";
                questionPanel.SetActive(true);
                firstButton.GetComponentInChildren<Text>().text = "Yes";
                secondButton.GetComponentInChildren<Text>().text = "No";
                secondButton.gameObject.SetActive(true);

                movements.DisableMovements();
                break;

            case "Door":
                headerText.text = "Open Door?";
                questionPanel.SetActive(true);
                firstButton.GetComponentInChildren<Text>().text = "Yes";
                secondButton.GetComponentInChildren<Text>().text = "No";
                secondButton.gameObject.SetActive(true);

                if (!door.condition && doHaveKey == false)
                {
                    headerText.text = "You need key!";
                    firstButton.GetComponentInChildren<Text>().text = "OK";
                    secondButton.gameObject.SetActive(false);
                }

                movements.DisableMovements();
                break;

            default:
                break;
        }
    }

    public void YesButton()
    {
        switch (headerText.text)
        {
            case "Take Key?":
                SoundManagerScript.PlaySound("key");
                doHaveKey = true;
                key.SetActive(false);
                break;
            case "Open Chest?":
                if (!chest.condition)
                {
                    SoundManagerScript.PlaySound("creak");
                    chest.OpenObject();
                    isChestOpen = true;
                }
                break;
            case "Open Door?":
                if (!door.condition && doHaveKey == true)
                {
                    SoundManagerScript.PlaySound("creak");
                    door.OpenObject();
                    Invoke("GameOverLogic", 1f);
                }
                break;
            default:
                break;
        }

        ExitQuestion();
    }

    public void ExitQuestion()
    {
        questionPanel.SetActive(false);
        movements.EnableMovements();
    }

    public void GameOverLogic()
    {
        gameOverPanel.SetActive(true);
        timer.StopTimer();
        currentScoreUI.text = timer.counter.ToString();
        if (timer.counter < PlayerPrefs.GetFloat("highScore"))
        {
            PlayerPrefs.SetFloat("highScore", timer.counter);
            timer.StopTimer();
        }
        bestScoreUI.text = PlayerPrefs.GetFloat("highScore").ToString();

        chest.CloseObject();
        isChestOpen = false;
        door.CloseObject();
        key.SetActive(true);
        doHaveKey = false;

        random.SpawnObjects();
    }

    public void ExitGameOverPanel()
    {
        gameOverPanel.SetActive(false);
        timer.counter = 0f;
    }
}
