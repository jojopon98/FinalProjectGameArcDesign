using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimulatorComplete : MonoBehaviour
{
    public Image SimulatorPiece;
    
    void Update()
    {
        if (Input.GetKey(KeyCode.Keypad9))
        {
            SimulatorPiece.GetComponent<Image>().color = Color.green;
        }
    }
}
