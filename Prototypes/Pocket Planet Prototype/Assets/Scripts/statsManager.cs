using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class statsManager : MonoBehaviour
{
	[Header("Planet Stats")]
	public int wealth = 0;
	public int pop = 0;
	public int faith = 0;
	public int ironPart = 0;
	public int icePart = 0;
	public int nickelPart = 0;
	public int goldPart = 0;
	public int planetLevel = 0;
	int newFaith;

	public float time = 5;
	public float spawntimer;
	public float speed = 10.0f;

	[Header("UI")]
	public Text PlanetWealthText;
	public Text PopulationText;
	public Text FaithPointsText;

	public Text debugPlanetLevel;

	[Header("Next Asteroid Properties")]
	public Text nextAsteroidGold;
	public Text nextAsteroidIce;
	public Text nextAsteroidNickel;
	public Text nextAsteroidIron;
	public Text nextAsteroidValue;
	public Text nextAsteroidDamage;


	//public GameObject terraPlanet;

	//public bool terraPlanetLive;
	//public SphereCollider terraSphere;

	//public GameObject rockPlanet;

	//public bool rockPlanetLive;
	//public SphereCollider rockSphere;

//	public GameObject goldPlanet;

	//public bool goldPlanetLive;
	//public SphereCollider goldSphere;


	//public Renderer terraRend;
	//public Renderer rockRend;
	//public Renderer goldRend;
	[Header("Gold Planet Properties")]
	public Mesh goldMesh1;
	public Mesh goldMesh2;
	public Mesh goldMeshFinal;
	public Material goldMat;
	public bool goldPlanetLive;
	[Header("Nickel Planet Properties")]
	public Mesh nickelMesh1;
	public Mesh nickelMesh2;
	public Mesh nickelMeshFinal;
	public bool nickelPlanetLive;
	[Header("Ice Planet Properties")]
	public Mesh iceMesh1;
	public Mesh iceMesh2;
	public Mesh iceMeshFinal;
	public Material iceMat;
	public bool icePlanetLive;
	[Header("Core Planet Properties")]
	public GameObject stage1;
	public SphereCollider stage1col;
	public GameObject stage2;
	public SphereCollider stage2col;
	public GameObject finalStage;
	public SphereCollider finalCol;

	public ParticleSystem planetSmoke;

	public SphereCollider gravityFieldSize;
	public GameObject gravityField;
	public GameObject planet;

	private Transform nearest ;


	void Start ()
	{

		gravityFieldSize = gravityField.GetComponent<SphereCollider> ();


		StartCoroutine(spawnTime());

		nearest = Findnearest();

	}



	void Update()
	{


		nearest = Findnearest();


		if (nearest != null) 
		{
			Debug.Log ("Next Asteroid Contains - Gold = " + nearest.gameObject.GetComponent<asteroidStats>().gold +" Ice = " + nearest.gameObject.GetComponent<asteroidStats>().ice +" Nickel = " + nearest.gameObject.GetComponent<asteroidStats>().nickel +" Iron = " + nearest.gameObject.GetComponent<asteroidStats>().iron);
		}

		nextAsteroidGold.text = nearest.gameObject.GetComponent<asteroidStats> ().gold.ToString ();
		nextAsteroidIce.text = nearest.gameObject.GetComponent<asteroidStats> ().ice.ToString ();
		nextAsteroidNickel.text = nearest.gameObject.GetComponent<asteroidStats> ().nickel.ToString ();
		nextAsteroidIron.text = nearest.gameObject.GetComponent<asteroidStats> ().iron.ToString ();

		PlanetWealthText.text = wealth.ToString();
		PopulationText.text = pop.ToString ();
		FaithPointsText.text = faith.ToString ();

		debugPlanetLevel.text = planetLevel.ToString ();

		planet.transform.Rotate (0, Time.deltaTime*5, Time.deltaTime*10);

		if (planetLevel == 13) 
		{

			changePlanetTypeStage1();
			planetLevel +=1;
		}

		if (planetLevel == 20) 
		{

			changePlanetTypeStage2();
			planetLevel +=1;
		}

		if (planetLevel == 25) 
		{

			changePlanetTypeFinalStage();
			planetLevel +=1;
		}

		if (wealth <= 0) 
		{
			wealth = 0;
		}

	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "rock") 
		{
			planetLevel += 1;
			addScore ();

			col.gameObject.transform.position = new Vector3 (5000, 5000, 5000);

			Destroy (col.gameObject,5);

			ironPart += col.gameObject.GetComponent<asteroidStats> ().iron;
			icePart += col.gameObject.GetComponent<asteroidStats> ().ice;
			nickelPart += col.gameObject.GetComponent<asteroidStats> ().nickel;
			goldPart += col.gameObject.GetComponent<asteroidStats> ().gold;

		}
	}


	void changePlanetTypeStage1()
	{



		if (goldPlanetLive == true) 
		{
			changePlanetGoldStage1 ();
		} 

		if (icePlanetLive == true)
		{
			changePlanetIceStage1 ();
		}
	}

	void changePlanetTypeStage2()
	{
		if (goldPlanetLive == true) 
		{
			changePlanetGoldStage2 ();
		} 

		if (icePlanetLive == true)
		{
			changePlanetIceStage2 ();
		}
	}

	void changePlanetTypeFinalStage()
	{
		if (goldPlanetLive == true) 
		{
			changePlanetGoldFinalStage ();
		} 

		if (icePlanetLive == true)
		{
			changePlanetIceFinalStage ();
		}
	}

	void changePlanetSize()
	{
		gravityField.transform.localScale += new Vector3(0.1F, 0.1F, 0.1F);
		planet.transform.localScale += new Vector3(0.1F, 0.1F, 0.1F);
		planetSmoke.Play ();

	}
		
//************************************GOLD PLANET*****************************************
	void changePlanetGoldStage1()
	{
		stage1.gameObject.GetComponent<MeshFilter>().mesh = goldMesh1;
		stage1.gameObject.GetComponent<Renderer>().material = goldMat;
		stage1col.enabled = true;
		gravityFieldSize.radius = 480;
		pop +=1000;
	}

	void changePlanetGoldStage2()
	{
		stage2.gameObject.GetComponent<MeshFilter>().mesh = goldMesh2;
		stage2.gameObject.GetComponent<Renderer>().material = goldMat;
		stage1col.enabled = false;
		stage2col.enabled = true;
		gravityFieldSize.radius = 480;
		pop +=1000;
	}

	void changePlanetGoldFinalStage()
	{
		finalStage.gameObject.GetComponent<MeshFilter>().mesh = goldMeshFinal;
		finalStage.gameObject.GetComponent<Renderer>().material = goldMat;
		finalCol.enabled = true;
		stage2col.enabled = false;
		gravityFieldSize.radius = 480;
		pop +=1000;
	}

//************************************ICE PLANET*****************************************

	void changePlanetIceStage1()
	{
		stage1.gameObject.GetComponent<MeshFilter>().mesh = iceMesh1;
		stage1.gameObject.GetComponent<Renderer>().material = iceMat;
		stage1col.enabled = true;
		gravityFieldSize.radius = 480;
		pop +=1000;
	}

	void changePlanetIceStage2()
	{
		stage2.gameObject.GetComponent<MeshFilter>().mesh = iceMesh2;
		stage2.gameObject.GetComponent<Renderer>().material = iceMat;
		stage1col.enabled = false;
		stage2col.enabled = true;
		gravityFieldSize.radius = 480;
		pop +=1000;
	}

	void changePlanetIceFinalStage()
	{
		finalStage.gameObject.GetComponent<MeshFilter>().mesh = iceMeshFinal;
		finalStage.gameObject.GetComponent<Renderer>().material = iceMat;
		finalCol.enabled = true;
		stage2col.enabled = false;
		gravityFieldSize.radius = 480;
		pop +=1000;
	}




	IEnumerator spawnTime()
	{
		yield return new WaitForSeconds(time);

		pop += 1;
		if (wealth >= 10  && pop >= 10)
		{
		addFaith();
		}
		StartCoroutine(spawnTime());


	}




	void addPop()
	{
		pop += 1000;
	}

	void addScore()
	{
		if (planetLevel >= 10)
		{
			wealth += 10;
			pop -= 100;
		}

		if (pop <= 0) 
		{
			pop = 0;
		}



	}

	void addFaith()
	{
		
		newFaith = pop/50 + wealth / 20;

		faith = faith + newFaith;



		if (faith <= 0)
		{
		faith = 0;
		}
	}



	public Transform Findnearest()
	{
		GameObject[] candidates = GameObject.FindGameObjectsWithTag("rock");
		float minDistance = Mathf.Infinity;
		Transform closest ;

		if (candidates.Length == 0)
			return null;

		closest = candidates[0].transform;
		for ( int i = 1 ; i < candidates.Length ; ++i )
		{
			float distance = (candidates[i].transform.position - transform.position).sqrMagnitude;

			if ( distance < minDistance )
			{
				closest = candidates[i].transform;
				minDistance = distance;
			}

		}    
		return closest;
	}    





}
			
