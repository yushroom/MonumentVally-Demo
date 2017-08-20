using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTween : MonoBehaviour {

	public float time = 2.0f;

	public bool isPlaying = false;

	public void ApplyTween()
	{
		if (isPlaying)
			return;
		Vector3 t = transform.eulerAngles;
		t.y += 90;
		LeanTween.rotateLocal (gameObject, t, time).setOnComplete(()=>{
			isPlaying = false;
		});
		isPlaying = true;

	}
}
