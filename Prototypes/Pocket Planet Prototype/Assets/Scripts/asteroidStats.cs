using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class asteroidStats : MonoBehaviour {

    public int iron = 0;
    public int ice = 0;
    public int nickel = 0;
    public int gold = 0;

    public bool statsAdded = false;
	public bool statsVisable = false;
	public Image statLabel;

	public Text ironStat;
	public Text iceStat;
	public Text nickelStat;
	public Text goldStat;


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "AsteroidStatGiver" && statsAdded == false)
        {
            statsAdded = true;

            iron = Random.Range(1, 20);
            ice = Random.Range(1, 20);
            nickel = Random.Range(1, 20);
            gold = Random.Range(1, 20);

            Debug.Log("collided");

			addStats ();

        }
    }

	void addStats()
	{
		ironStat.text = iron.ToString();
		iceStat.text = ice.ToString ();
		nickelStat.text = nickel.ToString ();
		goldStat.text = gold.ToString ();
	}

    void Update () 
	{
		if (statsVisable == true)
		{
			Vector3 statPos = Camera.main.WorldToScreenPoint (this.transform.position);
			statLabel.transform.position = statPos;
		}
		if (statsVisable == false)
		{
			//Vector3 statPos = Camera.main.WorldToScreenPoint (this.transform.position);
			//statLabel.transform.position = new Vector3 (0,900,0);
		}



	

			}
	}﻿
	

