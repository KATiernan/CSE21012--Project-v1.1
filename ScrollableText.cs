using UnityEngine;
using System.Collections;

public class ScrollableText : MonoBehaviour {
//variable to change how fast text scrolls

	public float scrollSpeed = 20;
	isScrolling = true;

	void Update () {
		if (Input.GetMouseButtonDown(0))
            		Debug.Log("Pressed left click.");
		{
			isScrolling = !isScrolling;
		}
		if (isScrolling) {
		Vector3 pos = transform.position;
		Vector3 localVectorUp = transform.TransformDirection(0,1,0);
		pos += localVectorUp * scrollSpeed * Time.deltaTime;
		transform.position = pos;
		}
		}


}