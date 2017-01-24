using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PROJECTILE_MOVEMENT : MonoBehaviour {
	public float scaleDuration = 1.0f;
	private float scaleTime = 0.0f;
	private Vector3 initialScale;
	public bool scaling = true;

	// Use this for initialization
	void Start () {
		initialScale = transform.localScale;
		transform.localScale = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		if (scaleTime < scaleDuration || scaling)
		{
			transform.localScale = initialScale * (scaleTime / scaleDuration);
			scaleTime += Time.deltaTime;
		}
	}
}
