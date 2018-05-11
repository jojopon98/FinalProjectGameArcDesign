using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeveloperEXPObtained : MonoBehaviour
{
    public Image DeveloperEXPPiece;
    public Text DevEXPGained;
    
    void Update()
    {
        if (Input.GetKey(KeyCode.Keypad1))
        {
            DeveloperEXPPiece.GetComponent<Image>().color = Color.green;
            DevEXPGained.text = "2/2";
        }
        if (Input.GetKey(KeyCode.Keypad8))
        {
            DeveloperEXPPiece.GetComponent<Image>().color = Color.red;
        }
    }
}
