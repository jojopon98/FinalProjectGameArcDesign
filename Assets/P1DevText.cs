using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P1DevText : MonoBehaviour
{
    public Text devCounter;
    public void changeTime (string devTime)
    {
        devCounter.text = devTime;
    }
}
