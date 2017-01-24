using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOCK_GRID : MonoBehaviour 
{
	private int pixelsPerUnit = 32;

	private Transform parent;

	private void Start()
	{
		parent = transform.parent;
	}

	private void LateUpdate() 
	{
		Vector3 newLocalPosition = Vector3.zero;

		newLocalPosition.x = (Mathf.Round(parent.position.x * pixelsPerUnit) / pixelsPerUnit) - parent.position.x;
		newLocalPosition.y = (Mathf.Round(parent.position.y * pixelsPerUnit) / pixelsPerUnit) - parent.position.y;

		transform.localPosition = newLocalPosition;
	}
}