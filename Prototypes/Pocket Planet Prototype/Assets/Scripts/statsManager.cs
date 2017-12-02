using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class statsManager : MonoBehaviour
{

	public int wealth = 0;
	public int pop = 0;
	public int faith = 0;

	public Text PlanetWealthText;
	public Text PopulationText;
	public Text FaithPointsText;

	public Text debugPlanetLevel;

	public int planetLevel = 0;

	public GameObject planet;

	public ParticleSystem planetSmoke;

	void Update()
	{
		PlanetWealthText.text = wealth.ToString();
		PopulationText.text = pop.ToString ();
		FaithPointsText.text = faith.ToString ();

		debugPlanetLevel.text = planetLevel.ToString ();

		//planet.transform.Rotate (0, Time.deltaTime, 0);

		if (planetLevel % 5 == 0 && planetLevel>=5) 
		{
			planetLevel += 1;
			changePlanet ();
		}
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "rock") 
		{
			planetLevel += 1;
			addScore ();
			Destroy (col.gameObject);


			//col.gameObject.transform.position = new Vector3 (1400, 450, -136);
			//col.gameObject.GetComponent<PlayerGravityBody> ().inGravityField = false;
			//col.gameObject.GetComponent<asteroidPath> ().onPath = true;
			//col.gameObject.GetComponent<asteroidStats>().statsAdded = false;
			//col.gameObject.GetComponent<Renderer>().material.color = Color.gray;

			//ParticleSystem.EmissionModule em = gameObject.GetComponentInChildren<ParticleSystem>().emission;
			//em.enabled = false;




		}
	}


	void changePlanet()
	{
		planet.transform.localScale += new Vector3(0.1F, 0.1F, 0.1F);
		planetSmoke.Play ();
	}



	void addScore()
	{
		if (planetLevel >= 10)
		{
			wealth += 10;
			//faith = wealth / 2;
			pop -= 10;
		}

		if (pop <= 0) 
		{
			pop = 0;
		}

		if (pop >= wealth) 
		{
			addFaith();
		}


	}

	void addFaith()
	{
		faith = pop + wealth / 2;
	}

}
			
