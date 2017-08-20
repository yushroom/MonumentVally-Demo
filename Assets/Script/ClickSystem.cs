using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class CubeEvent : UnityEvent<Cube> {
}

public class ClickSystem : MonoBehaviour {

	Cube[] cubes;

	// Use this for initialization
	void Start ()
	{
		cubes = Object.FindObjectsOfType<Cube> ();
	}

	public CubeEvent CubeClicked;
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			float distance = Mathf.Infinity;
			Cube target = null;
			foreach (var c in cubes)
			{
				var col = c.GetComponent<Collider>();
				if (col.Raycast (ray, out hit, distance))
				{
					distance = hit.distance;
					target = hit.collider.gameObject.GetComponent<Cube> ();
				}
			}

			if (target) {
				CubeClicked.Invoke (target);
			}
		}
	}
}
