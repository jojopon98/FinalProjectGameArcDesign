using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageController : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }
    public void Switch()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
