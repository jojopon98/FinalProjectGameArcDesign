using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceQueue : MonoBehaviour {
    public Color color;
    public Queue<Image> Spaces;
    public Image currentSpace;
    public List<Image> testList;
    public bool P1;
    public int Goal;
	void Start () {
        Spaces = new Queue<Image>();
	}
    public void Move(int from, int to)
    {
        Goal = to;
        for (int i = from; i <= to; i++)
        {
            Spaces.Enqueue(GameManager.Instance.GetSpace(i));
        }
        LightSpaces();
    }
    void LightSpaces()
    {
        StartCoroutine(LightNextSpace());
    }

    IEnumerator LightNextSpace()
    {
        if (currentSpace != null)
        {
            // turn off the current space
            currentSpace.color = Color.white;
        }
        while (Spaces.Count > 0)
        {
            // get a new current space from stack
            currentSpace = Spaces.Dequeue();
            // change the current space to red
            currentSpace.color = color;
            // wait
            yield return new WaitForSeconds(1);
            if (Spaces.Count > 0 && currentSpace != null)
            {
                // turn off the current space
                currentSpace.color = Color.white;
            }
        }
        if (P1)
        {
            GameManager.Instance.P1Position = Goal;
        }
        else
        {
            GameManager.Instance.P2Position = Goal;
        }
        GameManager.Instance.StartDecision(P1);
    }

	void Update () {
		
	}
}
