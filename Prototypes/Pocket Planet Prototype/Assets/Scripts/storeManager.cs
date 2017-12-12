using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class storeManager : MonoBehaviour {

	public GameObject menuPanel;

	public GameObject itemSpawnLocation;

	public GameObject parentPlanet;

	public Transform CactusItem;

	public Button Cactus;

	public bool hasHit;

	public int cactusPrice = 50;

	void Start () 
	{
		menuPanel.gameObject.SetActive (false);

		Button buyCactus = Cactus.GetComponent<Button> ();
		buyCactus.onClick.AddListener (purchaseCactus);


	}

	void purchaseCactus()
	{
		Debug.Log ("cactus bought");
		if (parentPlanet.gameObject.GetComponent<statsManager> ().faith >= cactusPrice)
		{
			var newCactus = Instantiate (CactusItem, new Vector3 (itemSpawnLocation.GetComponent<Transform> ().position.x, itemSpawnLocation.GetComponent<Transform> ().position.y, 0), Quaternion.Euler (-90, 0, -180));
			parentPlanet.gameObject.GetComponent<statsManager> ().faith -= cactusPrice;
		}
		if (parentPlanet.gameObject.GetComponent<statsManager> ().faith <= cactusPrice) 
		{
			Debug.Log ("Not Enough Faith");
		}
	}


	// Update is called once per frame
	void Update ()
	{

		if (parentPlanet.gameObject.GetComponent<statsManager> ().faith <= 0) 
		{
			parentPlanet.gameObject.GetComponent<statsManager> ().faith = 0;
		}
	}
}
