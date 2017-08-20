using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotSystem : MonoBehaviour {

	Slot[] slots;

	// Use this for initialization
	void Start ()
	{
		slots = Object.FindObjectsOfType<Slot> ();

		InvokeRepeating ("Check", 1, 0.2f);
	}
		
	void Check ()
	{
		var cam = Camera.main;
		var points = new Vector3[slots.Length];
		for (int i = 0; i < slots.Length; ++i)
		{
			slots [i].matched = null;
			points [i] = cam.WorldToViewportPoint (slots[i].transform.position);
			points [i].z = 0;
		}
		for (int i = 0; i < slots.Length; ++i)
		{
			for (int j = i+1; j < slots.Length; ++j)
			{
				if (Vector3.Distance (points [i], points [j]) < 0.001f)
				{
					slots[i].matched = slots[j];
					slots [j].matched = slots [i];
				}
			}
		}
	}
}
