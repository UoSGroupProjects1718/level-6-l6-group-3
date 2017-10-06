using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class astroids : MonoBehaviour { 
	public SpriteRenderer Sprite; 
	public GameObject particles; 
	public GameObject astriod; 
	public TrailRenderer trail; 
	public Rigidbody2D rb; 
	public float thrust; 

	// Use this for initialization
	void Start () {
		rb = GetComponent <Rigidbody2D> (); 
		rb.AddForce (transform.right * thrust);
	}
	
	// Update is called once per frame
	void Update () {
		
	} 
	void OnMouseDown() {
		Debug.Log ("click"); 
		Destroy (Sprite); 
		Destroy (trail);
		particles.SetActive (true); 

		} 
	IEnumerator endp () {
		yield return new WaitForSeconds (1.5f); 
		Destroy (astriod);
	}
}
