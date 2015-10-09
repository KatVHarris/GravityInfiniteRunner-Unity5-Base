using UnityEngine;
using System.Collections;

public class TestDestroyer : MonoBehaviour {
	
	//public GameObject PlatformController; 
	private TestSpawner platformControllerScript;  

	//SEPERATED
	//private TestPlatformController platformControllerScript; 
	// Use this for initialization
	void Start () {
		platformControllerScript = GameObject.Find ("PlatformController").GetComponent<TestSpawner> (); 
		
	}
	public void Awake(){
		//controllerScript = PlatformController.GetComponent<TestSpawner> ();
		//platformControllerScript = PlatformController.GetComponent<Spawner> (); 


		//SEPERATED 
		//platformControllerScript = PlatformController.GetComponent<TestPlatformController> (); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider other){
		
		//controllerScript.RemoveBox (other.gameObject);
		string collideTag = other.tag;
		
		if(collideTag == "Player"){
			
		}
		
		if (collideTag == "BottomPlatform") {
			//if(other.gameObject.transform.parent.transform.parent != null)
				//platformControllerScript = (TestSpawner) other.gameObject.transform.parent.transform.parent.gameObject.GetComponent<TestSpawner>();
				platformControllerScript.RemoveBottomPlatform(other.gameObject); //<TestSpawn> activePlatforms.count = 0 for all lists
			//GetComponent<TestSpawner>().RemoveBottomPlatform(other.gameObject); //ERROR: Object reference not set to an instance of an object
			//other.gameObject.transform.parent.transform.parent.gameObject.GetComponent<TestSpawner>().RemoveBottomPlatform(other.gameObject); //ERROR: No TestSpawner
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
