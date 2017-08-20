using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
	public Cube cube;
	public Slot matched;

	void OnDrawGizmos()
	{
		if (matched == null) {
			Gizmos.color = Color.red;
		} else {
			Gizmos.color = Color.green;
		}
		Gizmos.matrix = transform.localToWorldMatrix;
		Gizmos.DrawCube (Vector3.zero, Vector3.one*0.1f);
		Gizmos.matrix = Matrix4x4.identity;
	}
}
