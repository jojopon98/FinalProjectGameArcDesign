using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementPanel : MonoBehaviour
{
    public Button[] Buttons;
    bool P1;
    int Distance;
    int Choice;
    public Text moneyText;
    public Text timeText;
    public int Money;
    public void Setup(int distance, bool p1)
    {
        Choice = -1;
        Money = 0;
        P1 = p1;
        Distance = distance;
        for (int i = 1; i <= 6; i++)
        {
            if (i <= distance)
            {
                Buttons[i - 1].gameObject.SetActive(true);
            }
            else
            {
                Buttons[i - 1].gameObject.SetActive(false);
            }
        }
    }
    public void Choose(int choice)
    {
        Choice = choice;
        Money = (int)Mathf.Pow(100, 1 + choice / 10.0f);
        moneyText.text = "Money Earned: " + ((int) Mathf.Pow(100, 1 + choice / 10.0f));
        timeText.text = "Time Spent: " + choice * 2.5f + " weeks";
    }

    public void Move()
    {
        if (Choice == -1)
        {
            return;
        }
        if (P1)
        {
            GameManager.Instance.MoveP1(Choice, Money);
        }
        else
        {
            GameManager.Instance.MoveP2(Choice, Money);
        }
        gameObject.SetActive(false);
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
