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
	public Button zero;
	public Button one;
	public Button two;
	public Button three;
	public Button four;
	public Button five;
	public Button six;
	public Button seven;
	public Button eight;
	public Button nine;
	public Button ten;





	public bool hasHit;
	public int treePrice = 50;
	public int pyramidPrice = 50;
	public int shipPrice = 150;


	public int itemNumber;

	public GameObject[] storeItems;

	void Start () 
	{
		menuPanel.gameObject.SetActive (false);


		Button element0 = zero.GetComponent<Button> ();
		element0.onClick.AddListener (buyElement0);

		Button element1 = one.GetComponent<Button> ();
		element1.onClick.AddListener (buyElement1);

		Button element2 = two.GetComponent<Button> ();
		element2.onClick.AddListener (buyElement2);

		Button element3 = three.GetComponent<Button> ();
		element3.onClick.AddListener (buyElement3);

		Button gatcha = Gatcha.GetComponent<Button> ();
		gatcha.onClick.AddListener (ActivateGatcha);

	}

	void buyItem()
	{
		for (int i = 0; i < itemNumber; i++) 
		{
			Instantiate(storeItems[i], new Vector3 (itemSpawnLocation.GetComponent<Transform> ().position.x, itemSpawnLocation.GetComponent<Transform> ().position.y, itemSpawnLocation.GetComponent<Transform> ().position.z), Quaternion.Euler (-90, 0, -180));
		}
	}

	void buyElement0()
	{
		Debug.Log ("castle bought");
		if (parentPlanet.gameObject.GetComponent<statsManager> ().faith <= shipPrice) 
		{
			Debug.Log ("Not Enough Faith");
		}
		Instantiate(storeItems[0], new Vector3 (itemSpawnLocation.GetComponent<Transform> ().position.x, itemSpawnLocation.GetComponent<Transform> ().position.y, itemSpawnLocation.GetComponent<Transform> ().position.z), Quaternion.Euler (-90, 0, -180));
	}

	void buyElement1()
	{
		Debug.Log ("container ship  bought");
		if (parentPlanet.gameObject.GetComponent<statsManager> ().faith <= shipPrice) 
		{
			Debug.Log ("Not Enough Faith");
		}
		Instantiate(storeItems[1], new Vector3 (itemSpawnLocation.GetComponent<Transform> ().position.x, itemSpawnLocation.GetComponent<Transform> ().position.y, itemSpawnLocation.GetComponent<Transform> ().position.z), Quaternion.Euler (-90, 0, -180));
	}

	void buyElement2()
	{
		Debug.Log ("crane bought");
		if (parentPlanet.gameObject.GetComponent<statsManager> ().faith <= shipPrice) 
		{
			Debug.Log ("Not Enough Faith");
		}
		Instantiate(storeItems[2], new Vector3 (itemSpawnLocation.GetComponent<Transform> ().position.x, itemSpawnLocation.GetComponent<Transform> ().position.y, itemSpawnLocation.GetComponent<Transform> ().position.z), Quaternion.Euler (-90, 0, -180));
	}

	void buyElement3()
	{
		Debug.Log ("crator bought");
		if (parentPlanet.gameObject.GetComponent<statsManager> ().faith <= shipPrice) 
		{
			Debug.Log ("Not Enough Faith");
		}
		Instantiate(storeItems[3], new Vector3 (itemSpawnLocation.GetComponent<Transform> ().position.x, itemSpawnLocation.GetComponent<Transform> ().position.y, itemSpawnLocation.GetComponent<Transform> ().position.z), Quaternion.Euler (-90, 0, -180));
	}

	void ActivateGatcha()
	{
		Instantiate(storeItems[Random.Range(0,20)], new Vector3 (itemSpawnLocation.GetComponent<Transform> ().position.x, itemSpawnLocation.GetComponent<Transform> ().position.y, itemSpawnLocation.GetComponent<Transform> ().position.z), Quaternion.Euler (-90, 0, -180));
		parentPlanet.gameObject.GetComponent<statsManager> ().faith -= 100;
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
