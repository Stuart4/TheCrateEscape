using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public float minSpawn = 1f;
	public float maxSpawn = 2f;
	public int poolDepth = 4;
	public GameObject[] objs;
	private GameObject[,] pool;
	// Use this for initialization
	void Start () {
		pool = new GameObject[objs.Length, poolDepth];
		for (int i = 0; i < objs.Length; i++) {
			for (int j = 0; j < poolDepth; j++) {
				pool[i, j] = (GameObject) Instantiate(objs[i]);
				pool[i, j].SetActive(false);
			}
		}
		Spawn();
	}
	
	void Spawn () {
		int lane = Random.Range(0, objs.Length);
		for (int i = 0; i < poolDepth; i++) {
			if (!pool[lane, i].activeSelf) {
				pool[lane, i].transform.position = transform.position;
				pool[lane, i].SetActive(true);
				break;
			}
		}
		Invoke("Spawn", Random.Range(minSpawn, maxSpawn));
	}
}
