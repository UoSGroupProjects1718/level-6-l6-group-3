using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class loadScene : MonoBehaviour {

	public Button scene;
	void Start () 
	{
		Button load = scene.GetComponent<Button> ();
		load.onClick.AddListener (openScene);
	}


	void openScene()
	{

		UnityEngine.SceneManagement.SceneManager.LoadScene(1);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
