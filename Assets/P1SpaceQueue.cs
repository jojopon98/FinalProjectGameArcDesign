using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P1SpaceQueue : MonoBehaviour
{

    public Queue<Image> Spaces;
    public Image currentSpace;
    public List<Image> testList;
    void Start()
    {
        Spaces = new Queue<Image>();
        foreach (Image i in testList)
        {
            Spaces.Enqueue(i);
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
            currentSpace.color = Color.red;
            // wait
            yield return new WaitForSeconds(1);
            if (Spaces.Count > 0 && currentSpace != null)
            {
                // turn off the current space
                currentSpace.color = Color.white;
            }
        }
        currentSpace = null;
    }

    void Update()
    {

    }
}