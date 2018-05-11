using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrototypeObtained : MonoBehaviour
{
    public Image PrototypePiece;
    public Text PrototypeGained;
    
    void Update()
    {
        if (Input.GetKey(KeyCode.Keypad3))
        {
            PrototypePiece.GetComponent<Image>().color = Color.green;
            PrototypeGained.text = "1/1";
        }
    }
}
