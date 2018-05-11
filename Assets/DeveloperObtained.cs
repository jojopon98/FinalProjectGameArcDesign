using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeveloperObtained : MonoBehaviour {

    public Image DeveloperPiece;
    public Text DeveloperCount;
    public Text DevEXPLost;

	void Update()
    {
        if (Input.GetKey(KeyCode.Keypad2))
        {
            DeveloperPiece.GetComponent<Image>().color = Color.green;
            DeveloperCount.text = "2/2";
            DevEXPLost.text = "0/2";
        }
    }
}
