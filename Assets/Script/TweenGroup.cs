using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenGroup : MonoBehaviour {

	public TransformTween[] tweens;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ApplyAll()
	{
		foreach (var t in tweens) {
			t.ApplyTween ();
		}
	}
}
