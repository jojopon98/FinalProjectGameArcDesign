using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecisionPanel : MonoBehaviour
{
    bool P1;
    int Perception;
    int Appeal;
    int Difficulty;
    int Budget;
    int type;
    int score;
    public Text SituationText;
    public Text DifficultyText;
    public Text AppealText;
    public Text BudgetText;
    public Text PerceptionText;
    public Button Accept;
    public Button Refuse;
    public void AcceptChoice()
    {
        if (P1)
        {
            GameManager.Instance.P1Money += Budget;
            GameManager.Instance.P1Difficulty += Difficulty;
            GameManager.Instance.P1Appeal += Appeal;
            GameManager.Instance.P1Perception += Perception;
        }
        else
        {
            GameManager.Instance.P2Money += Budget;
            GameManager.Instance.P2Difficulty += Difficulty;
            GameManager.Instance.P2Appeal += Appeal;
            GameManager.Instance.P2Perception += Perception;
        }
        GameManager.Instance.Moving = false;
        gameObject.SetActive(false);

    }
    public void RefuseChoice()
    {
        GameManager.Instance.Moving = false;
        gameObject.SetActive(false);

    }
    public void Setup(int square, bool p1)
    {
        int dif = GameManager.Instance.targetDifficulty;
        if (P1)
        {
            dif -= GameManager.Instance.P1Difficulty;
        }
        else
        {
            dif -= GameManager.Instance.P2Difficulty;
        }
        P1 = p1;
        Perception = 0;
        Appeal = 0;
        Difficulty = 0;
        Budget = 0;
        type = square;
        Refuse.gameObject.SetActive(true);
        DifficultyText.gameObject.SetActive(true);
        AppealText.gameObject.SetActive(true);
        BudgetText.gameObject.SetActive(true);
        PerceptionText.gameObject.SetActive(true);
        switch (type)
        {
            case 0:
                int currentAppeal;
                int currentPerception;
                int currentTime;
                if (P1)
                {
                    currentAppeal = GameManager.Instance.P1Appeal;
                }
                else
                {
                    currentAppeal = GameManager.Instance.P2Appeal;
                }
                if (P1)
                {
                    currentPerception = GameManager.Instance.P1Perception;
                }
                else
                {
                    currentPerception = GameManager.Instance.P2Perception;
                }
                if (P1)
                {
                    currentTime = GameManager.Instance.P1Position;
                }
                else
                {
                    currentTime = GameManager.Instance.P2Position;
                }
                score = (100 - Mathf.Abs(dif)) * (currentAppeal + currentPerception) * 50 / (100 * currentTime) * 1000000;
                SituationText.text = "You have a chance to release your game! Is it go time?";
                DifficultyText.gameObject.SetActive(false);
                AppealText.gameObject.SetActive(false);
                BudgetText.gameObject.SetActive(false);
                PerceptionText.gameObject.SetActive(false);
                break;
            case 1:
                SituationText.text = "A designer has taken an interest in your game! Do you want to hire them?";
                Budget = -Random.Range(1000, 2000);
                Perception = Random.Range(5, 10);
                break;
            case 2:
                SituationText.text = "A developer has taken an interest in your game! Do you want to hire them?";
                Budget = -Random.Range(1000, 2000);
                Difficulty = Random.Range(-5, 6);
                break;
            case 3:
                SituationText.text = "Your developers have gained experience and have a good idea! Do you want to fund it?";
                Budget = -Random.Range(500, 1000);
                Appeal = Random.Range(1, 10);
                break;
            case 4:
                SituationText.text = "You had a really crazy idea! Do you want to pursue it?";
                
                Perception = Random.Range(5, 10);
                Difficulty = Random.Range(-5, 6);
                Appeal = Random.Range(1, 10);
                int total = Perception + Appeal + Mathf.Abs(Difficulty);
                Budget = -Random.Range(10 * total, 20 * total);
                break;
            case 5:
                SituationText.text = "Critics have given an early review of your game. It is...";
               
                if (dif >= 25)
                {
                    SituationText.text += "way too high!!!";
                }
                else if (dif >= 15)
                {
                    SituationText.text += "too high!";
                }
                else if (dif > -15)
                {
                    SituationText.text += "good!";
                }
                else if (dif > 25)
                {
                    SituationText.text += "too low!";
                }
                else
                {
                    SituationText.text += "way too low!!!";
                }
                Refuse.gameObject.SetActive(false);
                DifficultyText.gameObject.SetActive(false);
                AppealText.gameObject.SetActive(false);
                BudgetText.gameObject.SetActive(false);
                PerceptionText.gameObject.SetActive(false);
                break;
            case 6:
                SituationText.text = "After a successful kickstarter, you've gotten Free Money for fake promises!!!!";
                Budget = Random.Range(1000, 3000);
                Refuse.gameObject.SetActive(false);
                break;

        }
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PerceptionText.gameObject.activeSelf)
        {
            PerceptionText.text = "Perception: " + Perception;
        }
        if (AppealText.gameObject.activeSelf)
        {
            AppealText.text = "Appeal: " + Appeal;
        }
        if (DifficultyText.gameObject.activeSelf)
        {
            DifficultyText.text = "Difficulty: " + Difficulty;
        }
        if (BudgetText.gameObject.activeSelf)
        {
            BudgetText.text = "Budget: " + Budget;
        }
    }
}
