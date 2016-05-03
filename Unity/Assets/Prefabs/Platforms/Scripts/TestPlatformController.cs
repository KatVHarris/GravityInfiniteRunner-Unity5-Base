using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestPlatformController : MonoBehaviour {

	public List<GameObject> PathPlatforms;
	public List<GameObject> NoPathPlatforms;
	
	public  List<GameObject> activeBottomPlatforms;
	public  List<GameObject> activeLeftPlatforms;
	public  List<GameObject> activeTopPlatforms;
	public  List<GameObject> activeRightPlatforms;

	public List<GameObject> ActiveBottomPlatforms
	{
		get { return activeBottomPlatforms; }
		set { activeBottomPlatforms = value; }
	}

	public List<GameObject> ActiveLeftPlatforms
	{
		get { return activeLeftPlatforms; }
		set { activeLeftPlatforms = value; }
	}

	public List<GameObject> ActiveTopPlatforms
	{
		get { return activeTopPlatforms; }
		set { activeTopPlatforms = value; }
	}

	public List<GameObject> ActiveRightPlatforms
	{
		get { return activeRightPlatforms; }
		set { activeRightPlatforms = value; }
	}

	private string bottomPlatformTag = "BottomPlatform";
	private string topPlatformTag = "TopPlatform";
	private string leftPlatformTag = "LeftPlatform";
	private string rightPlatformTag = "RightPlatform";
	
	public float leftPlatAdjustment = -3.5f; 
	public float rightPlatAdjustment = 3.5f; 
	public float topPlatAdjustment = 3f; 
	public float botPlatAdjustment = -3f; 

	GameObject spawnerObject;

	public TestSpawner spawner;

	// Use this for initialization
	void Start () {
        //spawnerObject = GameObject.Find ("PlatformSpawner");
        //spawner = spawnerObject.GetComponent<TestSpawner> ();
        //for (int i = 0; i<4; i++) {
        //    spawner.GeneratePlatformsTest ();
        //}
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if (tpc.activeBottomPlatforms.Count < 8)
			//spawner.CreatePlatforms ();
		

		if (tpc.activeLeftPlatforms.Count < 8)
			//spawner.CreatePlatforms ();

		if (tpc.activeBottomPlatforms.Count < 8)
			//spawner.CreatePlatforms ();
		
		if (this.activeBottomPlatforms.Count < 8)
			//spawner.CreatePlatforms ();
			*/
	}

	public void RemoveBottomPlatform(GameObject gobj){
		
		this.activeBottomPlatforms.Remove (gobj);
		GameObject.Destroy (gobj);

	}
	
	public void RemoveTopPlatform(GameObject gobj){
		/*
		if (gobj.gameObject.transform.parent) {
			this.activeTopPlatforms.Remove (gobj.gameObject.transform.parent.gameObject);
			GameObject.Destroy (gobj.gameObject.transform.parent.gameObject);
		} else {*/
		activeTopPlatforms.Remove (gobj);
		GameObject.Destroy (gobj);
		
	}
	public void RemoveLeftPlatform(GameObject gobj){
		
		activeLeftPlatforms.Remove (gobj);
		GameObject.Destroy (gobj);
		
	}
	public void RemoveRightPlatform(GameObject gobj){
		
		activeRightPlatforms.Remove (gobj);
		GameObject.Destroy (gobj);
		
	}
}
