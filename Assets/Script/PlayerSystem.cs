using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystem : MonoBehaviour {

	Player player;
	Cube[] cubes;

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player>();
		cubes = Object.FindObjectsOfType<Cube> ();
		foreach (var c in cubes) {
			if (Vector3.Distance (c.transform.position, player.transform.position) < 0.1f) {
				player.current = c;
				break;
			}
		}
		player.gameObject.transform.SetParent (player.current.transform);
	}

	void Update ()
	{
		if (player.path != null) {
			float d = player.walkSpeed * Time.deltaTime;
			Cube targetCube = player.path.First.Value;
			Vector3 target = player.path.First.Value.transform.position;
			float dist = Vector3.Distance (player.transform.position, target);
			if (dist < d) {
				player.transform.position = target;
				player.path.RemoveFirst ();
				if (player.path.Count == 0)
					player.path = null;
				player.current = targetCube;
				player.gameObject.transform.SetParent (player.current.transform);
			} else {
				Vector3 dir = Vector3.Normalize( target - player.transform.position );
				player.transform.position += dir * d;
			}
		}
	}

	public void OnCubeClicked(Cube cube)
	{
//		Debug.Log (cube);
		player.path = FindPath (player.current, cube);
	}

	static LinkedList<Cube> FindPath(Cube source, Cube dest)
	{
		if (source == dest) {
			return null;
		}
		var path = new LinkedList<Cube>();

		var nodes = new Dictionary<Cube, int>();
		nodes [source] = 0;

		var prev = new Dictionary<Cube, Cube> ();

		var todo = new LinkedList<Cube>();
		todo.AddLast (source);
		bool found = false;
		while (todo.Count > 0) {
			Cube cur = todo.First.Value;
			todo.RemoveFirst ();
			int distance = nodes [cur] + 1;
			foreach (var s in cur.slots) {
				if (s.matched) {
					Cube other = s.matched.cube;
					if (!nodes.ContainsKey (other)) {
						nodes [other] = distance;
						todo.AddLast (other);
						prev [other] = cur;
					}
					if (other == dest) {
						found = true;
						break;
					}
				}
			}
			if (found) {
				break;
			}
		}

		if (!found) {
			return null;
		}

		string path_str = "";
		Cube p = dest;
		while (p != source) {
			path_str += p.name + "<-";
			path.AddFirst (p);
			p = prev [p];
		}
		path_str += source.name;
//		Debug.Log (path_str);
		return path;
	}
}
