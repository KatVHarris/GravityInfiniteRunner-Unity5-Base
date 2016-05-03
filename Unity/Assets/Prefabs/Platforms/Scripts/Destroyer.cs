using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {

	private GameObject platform; 
	//private Spawner platformControllerScript;
    private TestSpawner platformControllerScript;
    // Use this for initialization

    PlayerHealthController playerHealth;
    GameObject player;
    void Start () {
	

	}
	public void Awake(){
        //platformControllerScript = PlatformController.GetComponent<Spawner> ();
        platform = GameObject.Find("PlatformController");
        platformControllerScript = platform.GetComponent<TestSpawner>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealthController>();
    }

	// Update is called once per frame
	void Update () {

    }

	void OnTriggerEnter(Collider other){

		//controllerScript.RemoveBox (other.gameObject);
		string collideTag = other.tag;

		if(collideTag == "Player")
        {
            PlayerHealthController.instantDeath = true; 
            playerHealth.Death();
		}

		Debug.Log ("Collision object: " + collideTag);
		if (collideTag == "BottomPlatform") {
			platformControllerScript.RemoveBottomPlatform(other.gameObject);
			GameController.score += 1; 
		}
		if (collideTag == "TopPlatform") {
			platformControllerScript.RemoveTopPlatform(other.gameObject);
			GameController.score += 1;
		}
		if (collideTag == "RightPlatform") {
			platformControllerScript.RemoveRightPlatform(other.gameObject);
			GameController.score += 1; 
		}
		if (collideTag == "LeftPlatform") {
			platformControllerScript.RemoveLeftPlatform(other.gameObject);
			GameController.score += 1; 
		}

        //Destroy(other);

        
		//ADD CODE TO HANDLE ENEMIES

//		if(other.gameObject.transform.parent){
//			Destroy(other.gameObject.transform.parent.gameObject);
//		}
//		else{
//			controllerScript = PlatformController.GetComponent<Spawner> ();
//			controllerScript.RemovePlatform(other.gameObject);
			//Destroy(other.gameObject);
//		}

		//controllerScript.RemovePlatform (other.gameObject);*/
	}
}
