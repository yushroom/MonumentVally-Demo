using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public Cube current;
	public float walkSpeed = 0.1f;

	public LinkedList<Cube> path;
}
