using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTween : MonoBehaviour {

	public Vector3 deltaEulerAngles = Vector3.zero;
	public float time = 2.0f;
	public float delay = 0.0f;
	bool isPlaying = false;
	public bool once = true;
	bool applied = false;

	public void ApplyTween()
	{
		if (applied && once)
			return;
		if (isPlaying)
			return;
		Vector3 t = transform.eulerAngles;
		t += deltaEulerAngles;
		LeanTween.rotateLocal (gameObject, t, time).setDelay(delay).setOnComplete(()=>{
			isPlaying = false;
		});
		isPlaying = true;
		applied = true;
	}
}
