using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAMERA_RES : MonoBehaviour {

	public int cameraHeight = 240;
	private const int pixelsPerUnit = 32;

	void Start () 
	{
		GetComponent<Camera>().orthographicSize = (float)cameraHeight / (float)pixelsPerUnit / 2.0f;
	}
}
