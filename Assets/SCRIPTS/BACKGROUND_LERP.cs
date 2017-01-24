using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BACKGROUND_LERP : MonoBehaviour {

	public Color lerpA;
	public Color lerpB;
	public float lerpSpeed = 0.1f;
	public float lerpTime = 0.0f;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		lerpTime += Time.deltaTime;
		Camera.main.backgroundColor = Color.Lerp(lerpA, lerpB, (Mathf.Sin(lerpTime * lerpSpeed) + 1.0f) * 0.5f);
	}
}