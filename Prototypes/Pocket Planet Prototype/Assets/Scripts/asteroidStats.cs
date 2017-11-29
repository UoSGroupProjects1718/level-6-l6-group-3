using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidStats : MonoBehaviour {

    public int iron = 0;
    public int ice = 0;
    public int nickel = 0;
    public int gold = 0;

    public bool statsAdded = false;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "AsteroidZone" && statsAdded == false)
        {
            statsAdded = true;

            iron = Random.Range(1, 20);
            ice = Random.Range(1, 20);
            nickel = Random.Range(1, 20);
            gold = Random.Range(1, 20);

            Debug.Log("collided");

        }
    }

	// Use this for initialization
	void Start ()
    {


    }

    // Update is called once per frame
    void Update () {
		
	}
}
