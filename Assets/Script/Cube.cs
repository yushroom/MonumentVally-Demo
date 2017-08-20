using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {

//	enum SlotDir {
//		x = 0,
//		_x = 1,
//		z = 2,
//		_z = 3,
//	};

	public Slot[] slots = new Slot[4];

	void OnDrawGizmos()
	{
		Gizmos.matrix = transform.localToWorldMatrix;
		Gizmos.color = Color.green;
		Gizmos.DrawSphere (Vector3.zero, 0.2f);

		Gizmos.matrix = Matrix4x4.identity;
		foreach (var s in slots)
		{
			if (s.matched)
			{
				Gizmos.DrawLine (s.transform.position, transform.position);
			}
		}
	}
}
