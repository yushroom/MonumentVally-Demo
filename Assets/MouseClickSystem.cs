using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseClickSystem : MonoBehaviour {

	public UnityEvent OnLeftMouseButtonClicked;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			OnLeftMouseButtonClicked.Invoke ();
		}
	}
}
