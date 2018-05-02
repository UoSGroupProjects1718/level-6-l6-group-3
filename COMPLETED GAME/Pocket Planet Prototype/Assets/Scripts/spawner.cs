using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
	public List<GameObject> prefabList = new List<GameObject>();

	public Transform SpawnerPos;
	public float time = 5;
	public float speed = 10.0f;

	void Start()
	{
		StartCoroutine(spawnTime());
	}

	IEnumerator spawnTime()
	{
		int prefabIndex = UnityEngine.Random.Range(0, 2);
		// Debug.Log(prefabIndex);
		Instantiate(prefabList[prefabIndex], SpawnerPos.transform.position, transform.rotation);

		yield return new WaitForSeconds(time);

		StartCoroutine(spawnTime());

	}

	void FixedUpdate()
	{

		float step = speed * Time.deltaTime;


	}
}
