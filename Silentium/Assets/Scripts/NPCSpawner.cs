using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NPCSpawner : MonoBehaviour {
	public GameObject District;
	public GameObject NPCPrefab;
	public int maxNPCCount;
	public float spawnInterval;
	public bool isSpawning;

	private List<GameObject> _npcs;

	void Start () {
		_npcs = new List<GameObject> ();
		StartCoroutine (Spawn ());	
	}

	private IEnumerator Spawn() {
		while (true) {
			if (isSpawning) {
				SpawnNPC ();
				yield return new WaitForSeconds (spawnInterval);
			}
		}
	}

	public void SpawnNPC() {
		CheckForDeadNpcs ();
		if (_npcs.Count < maxNPCCount) {
			var npc = Instantiate (NPCPrefab);
			npc.GetComponent<CivilianAI> ().District = District;
			npc.transform.position = this.transform.position;
			_npcs.Add (npc);
		}
	}

	private void CheckForDeadNpcs() {
		_npcs = _npcs.Where (npc => npc.GetComponent<PersonStats> ().isAlive).ToList ();
	}
}
