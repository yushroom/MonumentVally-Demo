using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateController : MonoBehaviour {

	public enum Direction {
		X, Y, Z
	}

	public enum Axis {
		Up, Left, Forward
	}

	public Transform target;
	public Space space = Space.Self;
	public Axis axis = Axis.Up;
	public float speed = 5.0f;
//	public Direction direction;

	// Use this for initialization
	void Start ()
	{
		if (target == null)
			target = transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButton (1))
		{
			float angle = -Input.GetAxis ("Mouse X") * speed;
//			transform.RotateAround (transform.position, Vector3.up, deltaX*5);
			Vector3 a;
			if (axis == Axis.Up)
				a = Vector3.up;
			else if (axis == Axis.Left)
				a = Vector3.left;
			else
				a = Vector3.forward;
			transform.Rotate(a, angle, space);
		}
	}

	void OnDrawGizmos()
	{
		Gizmos.matrix = transform.localToWorldMatrix;
		Gizmos.color = Color.yellow;
		Gizmos.DrawCube (Vector3.zero, new Vector3 (0.5f, 0.1f, 0.5f));
		Gizmos.matrix = Matrix4x4.identity;
	}
}
