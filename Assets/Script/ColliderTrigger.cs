using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColliderTrigger : MonoBehaviour {

	public UnityEvent triggerEnger;

	void OnTriggerEnter(Collider other)
	{
//		Debug.LogError ("here");
		triggerEnger.Invoke ();
	}
}
