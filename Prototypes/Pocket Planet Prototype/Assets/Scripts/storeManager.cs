using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class storeManager : MonoBehaviour {

	public GameObject menuPanel;
	public GameObject itemSpawnLocation;
	public GameObject parentPlanet;

	public Transform treeItem;
	public Transform PyramidItem;
	public Transform shipItem;

	public Button Gatcha;

	public Button treeButton;
	public Button PyramidButton;
	public Button shipButton;


	public bool hasHit;
	public int treePrice = 50;
	public int pyramidPrice = 50;
	public int shipPrice = 150;

	public GameObject[] storeItems;

	void Start () 
	{
		menuPanel.gameObject.SetActive (false);

		Button buytree = treeButton.GetComponent<Button> ();
		buytree.onClick.AddListener (purchasetree);

		Button buyPyramid = PyramidButton.GetComponent<Button> ();
		buyPyramid.onClick.AddListener (purchasePyramid);

		Button buyShip = shipButton.GetComponent<Button> ();
		buyShip.onClick.AddListener (purchaseShip);

		Button gatcha = Gatcha.GetComponent<Button> ();
		gatcha.onClick.AddListener (ActivateGatcha);

	}


	void purchasePyramid()
	{
		Debug.Log ("pyramid bought");
		if (parentPlanet.gameObject.GetComponent<statsManager> ().faith >= pyramidPrice)
		{
			var newPyramid = Instantiate (PyramidItem, new Vector3 (itemSpawnLocation.GetComponent<Transform> ().position.x, itemSpawnLocation.GetComponent<Transform> ().position.y, itemSpawnLocation.GetComponent<Transform> ().position.z), Quaternion.Euler (-90, 0, -180));
			parentPlanet.gameObject.GetComponent<statsManager> ().faith -= pyramidPrice;
		}
		if (parentPlanet.gameObject.GetComponent<statsManager> ().faith <= pyramidPrice) 
		{
			Debug.Log ("Not Enough Faith");
		}

	}


	void purchasetree()
	{
		Debug.Log ("tree bought");
		if (parentPlanet.gameObject.GetComponent<statsManager> ().faith >= treePrice)
		{
			var newtree = Instantiate (treeItem, new Vector3 (itemSpawnLocation.GetComponent<Transform> ().position.x, itemSpawnLocation.GetComponent<Transform> ().position.y, itemSpawnLocation.GetComponent<Transform> ().position.z), Quaternion.Euler (-90, 0, -180));
			parentPlanet.gameObject.GetComponent<statsManager> ().faith -= treePrice;
		}
		if (parentPlanet.gameObject.GetComponent<statsManager> ().faith <= treePrice) 
		{
			Debug.Log ("Not Enough Faith");
		}
	}

	void purchaseShip()
	{
		Debug.Log ("ship bought");
		if (parentPlanet.gameObject.GetComponent<statsManager> ().faith <= shipPrice) 
		{
			Debug.Log ("Not Enough Faith");
		}
		Instantiate(storeItems[0], new Vector3 (itemSpawnLocation.GetComponent<Transform> ().position.x, itemSpawnLocation.GetComponent<Transform> ().position.y, itemSpawnLocation.GetComponent<Transform> ().position.z), Quaternion.Euler (-90, 0, -180));
	}


	void ActivateGatcha()
	{
		Instantiate(storeItems[Random.Range(0,20)], new Vector3 (itemSpawnLocation.GetComponent<Transform> ().position.x, itemSpawnLocation.GetComponent<Transform> ().position.y, itemSpawnLocation.GetComponent<Transform> ().position.z), Quaternion.Euler (-90, 0, -180));
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
