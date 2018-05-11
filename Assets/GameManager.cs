using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<Image> spaceList;
    public int P1Position;
    public int P2Position;
    public int targetDifficulty;
    public int P1Goal;
    public int P2Goal;
    public int P1Time;
    public int P2Time;
    public int P1Money;
    public int P2Money;
    public int P1Perception;
    public int P2Perception;
    public int P1Appeal;
    public int P2Appeal;
    public int P1Difficulty;
    public int P2Difficulty;
    public Text P1PerceptionText;
    public Text P2PerceptionText;
    public Text P1AppealText;
    public Text P2AppealText;
    public Text P1DifficultyText;
    public Text P2DifficultyText;
    public static GameManager Instance;
    public SpaceQueue P1Queue;
    public SpaceQueue P2Queue;
    public MovementPanel movementPanel;
    public DecisionPanel decisionPanel;
    public Text P1MoneyText;
    public Text P1TimeText;
    public Text P2MoneyText;
    public Text P2TimeText;
    public bool Moving;
    public int[] Squares;
    public Image GetSpace(int index)
    {
        return spaceList[index % spaceList.Count];
    }
    // Use this for initialization
    void Start()
    {
        if (GameManager.Instance == null)
        {
            GameManager.Instance = this;
            targetDifficulty = Random.Range(5, 96);
        }
    }

    public int GetSquare(int distance)
    {
        return Squares[distance % 20];
    }
    public void TakeTurnP1()
    {
        if (Moving)
        {
            return;
        }
        int P1Movement = Random.Range(1, 7);
        movementPanel.gameObject.SetActive(true);
        movementPanel.Setup(P1Movement, true);
        Moving = true;
    }

    public void MoveP1(int distance, int money)
    {

        P1Goal = P1Position + distance;
        P1Time += distance;
        P1Queue.Move(P1Position, P1Goal);
        P1Position = P1Goal;
        P1Money += money;
    }

    public void TakeTurnP2()
    {
        if (Moving)
        {
            return;
        }
        int P2Movement = Random.Range(1, 7);
        movementPanel.gameObject.SetActive(true);
        movementPanel.Setup(P2Movement, false);
        Moving = true;
    }
    public void StartDecision(bool P1)
    {
        decisionPanel.gameObject.SetActive(true);
        if (P1)
        {
            decisionPanel.Setup(GetSquare(P1Position), P1);
        }

        else
        {
            decisionPanel.Setup(GetSquare(P2Position), P1);
        }
    }
    public void MoveP2(int distance, int money)
    {
        P2Goal = P2Position + distance;
        P2Time += distance;
        P2Queue.Move(P2Position, P2Goal);
        P2Position = P2Goal;
        P2Money += money;
    }
    // Update is called once per frame
    void Update()
    {
        P1MoneyText.text = "Budget: " + P1Money;
        P2MoneyText.text = "Budget: " + P2Money;
        P1PerceptionText.text = "Perception: " + P1Perception;
        P2PerceptionText.text = "Perception: " + P2Perception;
        P1AppealText.text = "Appeal: " + P1Appeal;
        P2AppealText.text = "Appeal: " + P2Appeal;
        P1DifficultyText.text = "Difficulty: " + P1Difficulty;
        P2DifficultyText.text = "Difficulty: " + P2Difficulty;
        P1TimeText.text = "Development Time: " + 2.5 * P1Time + " weeks";
        P2TimeText.text = "Development Time: " + 2.5 * P2Time + " weeks";
    }
}
