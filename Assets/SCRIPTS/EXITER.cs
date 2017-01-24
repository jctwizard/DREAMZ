using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXITER : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Cursor.visible = true;

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
}
