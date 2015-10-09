using UnityEngine;
using System.Collections;

public class ContactDestroyer : MonoBehaviour {

/*	public GameObject explosion;
	public GameControllerScript gameController; 

	public int scoreValue; 

	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if(gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameControllerScript>();
		}
		if(gameController == null){
			Debug.Log("Cannot find GameController Script");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		//What did the object collide with
		if(other.tag == "Shot"){
			//if shot then explode at objects current postion
			//Instantiate(explosion, transfrom.position, transfrom.rotation);
		}
		if(other.tag == "Player"){
			Debug.Log("Player Die");
		}
		gameController.AddScore(scoreValue);
		Destroy(other.gameObject);
		Destroy(gameObject);
	}

	*/
}
