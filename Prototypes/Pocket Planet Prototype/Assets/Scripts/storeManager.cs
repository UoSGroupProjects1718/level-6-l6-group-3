using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class storeManager : MonoBehaviour {

	public GameObject menuPanel;

	public Button Cactus;

	public GameObject itemSpawnLocation;

	public GameObject parentPlanet;

	public Transform CactusItem;

	public bool hasHit;

	void Start () 
	{
		menuPanel.gameObject.SetActive (false);

		Button buyCactus = Cactus.GetComponent<Button> ();
		buyCactus.onClick.AddListener (purchaseCactus);

	}

	void purchaseCactus()
	{
		Debug.Log ("cactus bought");
		var newCactus = Instantiate (CactusItem, new Vector3(itemSpawnLocation.GetComponent<Transform> ().position.x, itemSpawnLocation.GetComponent<Transform> ().position.y, 0), Quaternion.Euler(-90,0,-180));

	}


	// Update is called once per frame
	void Update ()
	{

		
	}
}
