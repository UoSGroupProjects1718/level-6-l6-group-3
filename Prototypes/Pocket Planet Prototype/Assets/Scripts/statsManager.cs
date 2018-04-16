using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class statsManager : MonoBehaviour
{

	public int wealth = 0;
	public int pop = 0;
	public int faith = 0;

	public int ironPart = 0;
	public int icePart = 0;
	public int nickelPart = 0;
	public int goldPart = 0;



	public Text PlanetWealthText;
	public Text PopulationText;
	public Text FaithPointsText;

	public Text debugPlanetLevel;

	public int planetLevel = 0;

	int newFaith;

	public float time = 5;

	public float spawntimer;

	public float speed = 10.0f;

	public GameObject planet;

	public GameObject gravityField;

	public GameObject terraPlanet;

	public bool terraPlanetLive;
	public SphereCollider terraSphere;

	public GameObject rockPlanet;

	public bool rockPlanetLive;
	public SphereCollider rockSphere;

	public GameObject goldPlanet;

	public bool goldPlanetLive;
	public SphereCollider goldSphere;


	public Renderer terraRend;
	public Renderer rockRend;
	public Renderer goldRend;

	public Mesh goldMesh1;
	public Mesh goldMesh2;
	public Mesh goldMeshFinal;

	public GameObject stage1;
	public SphereCollider stage1col;
	public GameObject stage2;
	public SphereCollider stage2col;
	public GameObject finalStage;
	public SphereCollider finalCol;

	public ParticleSystem planetSmoke;

	public SphereCollider gravityFieldSize;



	void Start ()
	{
		terraRend = terraPlanet.GetComponent<Renderer> ();

		//colRadius = planetCol.GetComponent<SphereCollider> ();

		gravityFieldSize = gravityField.GetComponent<SphereCollider> ();

		terraSphere = terraPlanet.GetComponent<SphereCollider> ();

		terraSphere.enabled = false;

		StartCoroutine(spawnTime());

	}



	void Update()
	{
		PlanetWealthText.text = wealth.ToString();
		PopulationText.text = pop.ToString ();
		FaithPointsText.text = faith.ToString ();

		debugPlanetLevel.text = planetLevel.ToString ();

		planet.transform.Rotate (0, Time.deltaTime*5, Time.deltaTime*10);

		if (planetLevel == 13) 
		{

			changePlanetType();
			planetLevel +=1;
		}

		if (planetLevel == 20) 
		{

			changePlanetType();
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
			Destroy (col.gameObject);

			ironPart += col.gameObject.GetComponent<asteroidStats> ().iron;
			icePart += col.gameObject.GetComponent<asteroidStats> ().ice;
			nickelPart += col.gameObject.GetComponent<asteroidStats> ().nickel;
			goldPart += col.gameObject.GetComponent<asteroidStats> ().gold;

		}
	}


	void changePlanetType()
	{
		if (ironPart >= 2000) 
		{
			changePlanetRocky ();
		}
		if (goldPart >= 20) {
			changePlanetGoldStage1 ();
		} 
		if (goldPart >= 100) {
			changePlanetGoldStage2 ();
		} 
		else 
		{
			changePlanetTerra ();
		}
	}

	void changePlanetSize()
	{
		gravityField.transform.localScale += new Vector3(0.1F, 0.1F, 0.1F);
		planet.transform.localScale += new Vector3(0.1F, 0.1F, 0.1F);
		planetSmoke.Play ();

	}


	void changePlanetTerra()
	{

		terraPlanetLive = true;
		terraRend.enabled = true;
		terraSphere.enabled = true;
		gravityFieldSize.radius = 480;
		pop +=1000;


	}

	void changePlanetRocky()
	{
		rockPlanetLive = true;
		rockRend.enabled = true;
		rockSphere.enabled = true;
		gravityFieldSize.radius = 480;
		pop +=1000;
	}

	void changePlanetGoldStage1()
	{
		goldPlanetLive = true;
		stage1.gameObject.GetComponent<MeshFilter>().mesh = goldMesh1;
		stage1col.enabled = true;
		gravityFieldSize.radius = 480;
		pop +=1000;
	}

	void changePlanetGoldStage2()
	{
		goldPlanetLive = true;
		stage2.gameObject.GetComponent<MeshFilter>().mesh = goldMesh2;
		stage2col.enabled = true;
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

}
			
