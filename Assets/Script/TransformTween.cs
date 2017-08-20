using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformTween : MonoBehaviour
{
	public float time = 2.0f;
	public float delay = 0.0f;
	public bool once = true;
	bool applied = false;
	public Vector3 positionDelta = Vector3.zero;

	public void ApplyTween() {
		if (once && applied)
			return;
		// iTween.MoveAdd(gameObject, iTween.Hash("amount", positionDelta, "time",time, "delay", delay, "isLocal", true));
		LeanTween.move(gameObject, transform.position + positionDelta, time).setDelay(delay);
		applied = true;
	}
}
