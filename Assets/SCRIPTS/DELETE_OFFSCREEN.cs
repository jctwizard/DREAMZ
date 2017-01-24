using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DELETE_OFFSCREEN : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnBecameInvisible2D()
	{
		Destroy(gameObject);
	}
}
