using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {
	
//	public List<GameObject> PathPlatforms;
	public List<GameObject> NoPathPlatforms;


    public List<GameObject> PathBottomPlatforms;
    public List<GameObject> PathLeftPlatforms;
    public List<GameObject> PathTopPlatforms;
    public List<GameObject> PathRightPlatforms;


    public List<GameObject> NPBottomPlatforms;
    public List<GameObject> NPLeftPlatforms;
    public List<GameObject> NPTopPlatforms;
    public List<GameObject> NPRightPlatforms;


	public List<GameObject> activeBottomPlatforms;
	public List<GameObject> activeLeftPlatforms;
	public List<GameObject> activeTopPlatforms;
	public List<GameObject> activeRightPlatforms;

	private string bottomPlatformTag = "BottomPlatform";
	private string topPlatformTag = "TopPlatform";
	private string leftPlatformTag = "LeftPlatform";
	private string rightPlatformTag = "RightPlatform";

	public float leftPlatAdjustment = -3.5f; 
	public float rightPlatAdjustment = 3.5f; 
	public float topPlatAdjustment = 3f; 
	public float botPlatAdjustment = -3f; 
	
	int difficulty = 2; 
	// Use this for initialization
	void Start () {
		//		for (int i = 0; i<4; i++) {
		this.GeneratePlatforms ();
		Debug.Log ("looping through start"); 
		//		}
	}
	
	// Update is called once per frame
	void Update () {
		
		if (activeBottomPlatforms.Count < 8)
			this.GeneratePlatforms ();
		
		
		if (activeLeftPlatforms.Count < 8)
			this.GeneratePlatforms ();
		
		if (activeTopPlatforms.Count < 8)
			this.GeneratePlatforms ();
		
		if (activeRightPlatforms.Count < 8)
			this.GeneratePlatforms ();
		
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
			this.activeTopPlatforms.Remove (gobj);
			GameObject.Destroy (gobj);

	}
	public void RemoveLeftPlatform(GameObject gobj){

			this.activeLeftPlatforms.Remove (gobj);
			GameObject.Destroy (gobj);

	}
	public void RemoveRightPlatform(GameObject gobj){

			this.activeRightPlatforms.Remove (gobj);
			GameObject.Destroy (gobj);

	}
	

	
	void GeneratePlatforms ()
	{
		int np = difficulty; 
		int p = 4 - difficulty; 
		if (this.activeBottomPlatforms.Count == 0) {
			GameObject x = (GameObject)GameObject.Instantiate (this.PathBottomPlatforms [0], new Vector3 (0, -3f, 0), Quaternion.identity);
			x.tag = bottomPlatformTag;
//			x.gameObject.tag = "BottomPlatform";
			this.activeBottomPlatforms.Add (x);
		}
		if (this.activeLeftPlatforms.Count == 0) {
			Quaternion leftRotate = Quaternion.AngleAxis (90, Vector3.forward);
			GameObject x = (GameObject)GameObject.Instantiate (this.PathLeftPlatforms [0], new Vector3 (-3f,0f, 0), leftRotate);
			x.tag = leftPlatformTag;
//			x.gameObject.tag = "LeftPlatform";
			this.activeLeftPlatforms.Add (x);
		}
		if (this.activeTopPlatforms.Count == 0) {
			Quaternion topRotate = Quaternion.AngleAxis(180, Vector3.forward);
			GameObject x = (GameObject)GameObject.Instantiate (this.PathTopPlatforms [0], new Vector3 (0, 3f, 0), topRotate);
			//x.gameObject.tag = "TopPlatform";
			x.tag = topPlatformTag;
			this.activeTopPlatforms.Add (x);
		}
		if (this.activeRightPlatforms.Count == 0) {
			Quaternion rightRotate = Quaternion.AngleAxis (-90, Vector3.forward);
			GameObject x = (GameObject)GameObject.Instantiate (this.PathRightPlatforms [0], new Vector3 (3f, 0, 0), rightRotate);
			//x.gameObject.tag = "RightPlatform";

			x.tag = rightPlatformTag;
			this.activeRightPlatforms.Add (x);
		}

		if (this.activeTopPlatforms.Count != 0 || this.activeRightPlatforms.Count != 0 || this.activeLeftPlatforms.Count != 0 || this.activeBottomPlatforms.Count != 0) {
			for (int s = 0; s<4; s++) {
				string nametag ="";
				switch (s) {
				case 0:
					nametag = bottomPlatformTag; 
					float val = Random.value; //will it be path or no path
					Vector3 lastBotPlatPos = this.activeBottomPlatforms [this.activeBottomPlatforms.Count - 1].transform.position;
					Quaternion noRotate = this.activeBottomPlatforms [this.activeBottomPlatforms.Count - 1].transform.rotation; //Quaternion.identity;
					if (val < .5) {
						if (np > 0) {
							np = np - 1;
							CreateNoPathPlatform(nametag, 0, botPlatAdjustment, lastBotPlatPos, noRotate);
							/*							int platformType = ((int)Random.value) % this.NoPathPlatforms.Count; 
							GameObject x = (GameObject)GameObject.Instantiate (this.NoPathPlatforms [platformType], new Vector3 (lastBotPlatPos.x + 14, 0, 0), Quaternion.identity);
							x.tag = "BottomPlatform";
												this.activeBottomPlatforms.Add (x);*/
						} else {
						//	CreatePathPlatform(nametag, 0, botPlatAdjustment, lastBotPlatPos, noRotate);
							p = p - 1;


						}
					} else {
						if (p > 0) {
							p = p - 1;
                            CreatePathPlatform(nametag, GrabPathPlatormBottom(nametag, 0, botPlatAdjustment, lastBotPlatPos, noRotate));
							/*int platformType = ((int)Random.value) % this.PathPlatforms.Count; 
							GameObject x = (GameObject)GameObject.Instantiate (this.PathPlatforms [platformType], new Vector3 (lastBotPlatPos.x + 14, 0, 0), Quaternion.identity);
							x.tag = "BottomPlatform";
							this.activeBottomPlatforms.Add (x);*/
						} else {
							np = np - 1;

							CreateNoPathPlatform(nametag, 0, botPlatAdjustment, lastBotPlatPos, noRotate);
							/*
							int platformType = ((int)Random.value) % this.NoPathPlatforms.Count; 
							
							GameObject x = (GameObject)GameObject.Instantiate (this.NoPathPlatforms [platformType], new Vector3 (lastBotPlatPos.x + 14, 0, 0), Quaternion.identity);
							x.tag = "BottomPlatform";
							this.activeBottomPlatforms.Add (x);*/
						}
					}
					break; 
				case 1: //Left
					nametag = leftPlatformTag; 
					
					float leftval = Random.value; //will it be path or no path
					Vector3 lastLeftPlatPos =  this.activeLeftPlatforms [this.activeLeftPlatforms.Count - 1].transform.position;; 
					Quaternion leftRotate = this.activeLeftPlatforms [this.activeLeftPlatforms.Count - 1].transform.rotation; ////Quaternion.AngleAxis (90, Vector3.forward);
					if (leftval < .5) {
						if (np > 0) {
							CreateNoPathPlatform(nametag, leftPlatAdjustment, 0, lastLeftPlatPos, leftRotate);
							
							np = np - 1;
							/*int platformType = ((int)Random.value) % this.NoPathPlatforms.Count; 
							GameObject x = ((GameObject)GameObject.Instantiate (this.NoPathPlatforms [platformType], new Vector3 (lastLeftPlatPos.x + 14, 3, 3.5f), leftRotate));
							x.tag = "LeftPlatform";
							this.activeLeftPlatforms.Add (x);
							*/
						} else {
							p = p - 1;
							//CreatePathPlatform(nametag, leftPlatAdjustment, 0, lastLeftPlatPos, leftRotate);
							/*int platformType = ((int)Random.value) % this.PathPlatforms.Count; 
							//this.activeLeftPlatforms.Add (
							//	(GameObject)GameObject.Instantiate (this.PathPlatforms [platformType], new Vector3 (lastLeftPlatPos.x + 14, 3, 3.5f), leftRotate));
							GameObject x = (GameObject)GameObject.Instantiate (this.PathPlatforms [platformType], new Vector3 (lastLeftPlatPos.x + 14, 3, 3.5f), leftRotate);
							x.gameObject.tag = "LeftPlatform";
							this.activeLeftPlatforms.Add (x);*/
						}
					} else {
						if (p > 0) {
							p = p - 1;
                            CreatePathPlatform(nametag, GrabPathPlatormBottom(nametag, leftPlatAdjustment, 0, lastLeftPlatPos, leftRotate));
							
							/*int platformType = ((int)Random.value) % this.PathPlatforms.Count; 
							//this.activeLeftPlatforms.Add (
							//	(GameObject)GameObject.Instantiate (this.PathPlatforms [platformType], new Vector3 (lastLeftPlatPos.x + 14, 3, 3.5f), leftRotate));
							GameObject x = (GameObject)GameObject.Instantiate (this.PathPlatforms [platformType], new Vector3 (lastLeftPlatPos.x + 14, 3, 3.5f), leftRotate);
							x.tag = "LeftPlatform";
							this.activeLeftPlatforms.Add (x);*/
						} else {
							np = np - 1;
							CreateNoPathPlatform(nametag, leftPlatAdjustment, 0, lastLeftPlatPos, leftRotate);
							
							/*
							int platformType = ((int)Random.value) % this.NoPathPlatforms.Count; 
							//this.activeLeftPlatforms.Add (
							//	(GameObject)GameObject.Instantiate (this.NoPathPlatforms [platformType], new Vector3 (lastLeftPlatPos.x + 14, 3, 3.5f), leftRotate));
							GameObject x = (GameObject)GameObject.Instantiate (this.NoPathPlatforms [platformType], new Vector3 (lastLeftPlatPos.x + 14, 3, 3.5f), leftRotate);
							x.tag = "LeftPlatform";
							this.activeLeftPlatforms.Add (x);*/
						}
					}
					break;
				case 2: //Top
					nametag = topPlatformTag; 
					
					float topval = Random.value; //will it be path or no path
					//				Debug.Log ("Top random val: " + topval); 
					
					Vector3 lastTopPlatPos = this.activeTopPlatforms [this.activeTopPlatforms.Count - 1].transform.position;
					Quaternion topRotate = this.activeTopPlatforms [this.activeTopPlatforms.Count - 1].transform.rotation; //Quaternion.AngleAxis (180, Vector3.forward);
					if (topval < .5) {
						if (np > 0) {
							np = np - 1;
							CreateNoPathPlatform(nametag, 0, topPlatAdjustment, lastTopPlatPos, topRotate);
							/*
							int platformType = ((int)Random.value) % this.NoPathPlatforms.Count; 
							//this.activeTopPlatforms.Add (
							//	(GameObject)GameObject.Instantiate (this.NoPathPlatforms [platformType], new Vector3 (lastTopPlatPos.x + 14, 6.5f, 0), topRotate));
							GameObject x = (GameObject)GameObject.Instantiate (this.NoPathPlatforms [platformType], new Vector3 (lastTopPlatPos.x + 14, 6.5f, 0), topRotate);
							x.tag = "TopPlatform";
							this.activeTopPlatforms.Add (x);*/
						} else {
							p = p - 1;
                            CreatePathPlatform(nametag, GrabPathPlatformTop(nametag, 0, topPlatAdjustment, lastTopPlatPos, topRotate));
							
							/*int platformType = ((int)Random.value) % this.PathPlatforms.Count; 
							//this.activeTopPlatforms.Add (
							//	(GameObject)GameObject.Instantiate (this.PathPlatforms [platformType], new Vector3 (lastTopPlatPos.x + 14, 6.5f, 0), topRotate));
							p = p - 1;
							GameObject x = (GameObject)GameObject.Instantiate (this.PathPlatforms [platformType], new Vector3 (lastTopPlatPos.x + 14, 6.5f, 0), topRotate);
							x.tag = "TopPlatform";
							this.activeTopPlatforms.Add (x);*/
						}
					} else {
						if (p > 0) {
							p = p - 1;
                            CreatePathPlatform(nametag, GrabPathPlatformTop(nametag, 0, topPlatAdjustment, lastTopPlatPos, topRotate));
							/*
							int platformType = ((int)Random.value) % this.PathPlatforms.Count; 
							//this.activeTopPlatforms.Add (
							//	(GameObject)GameObject.Instantiate (this.NoPathPlatforms [platformType], new Vector3 (lastTopPlatPos.x + 14, 6.5f, 0), topRotate));
							GameObject x = (GameObject)GameObject.Instantiate (this.PathPlatforms [platformType], new Vector3 (lastTopPlatPos.x + 14, 6.5f, 0), topRotate);
							x.tag = "TopPlatform";
							this.activeTopPlatforms.Add (x);*/
						} else {
							//		Debug.Log ("np before adding platform: " +np);
							np = np - 1;
							CreateNoPathPlatform(nametag, 0, topPlatAdjustment, lastTopPlatPos, topRotate);
							
							//		Debug.Log("np after addition: " +np);	
							/*
							int platformType = ((int)Random.value) % this.NoPathPlatforms.Count; 
							GameObject x = (GameObject)GameObject.Instantiate (this.NoPathPlatforms [platformType], new Vector3 (lastTopPlatPos.x + 14, 6.5f, 0), topRotate);
							x.tag = "TopPlatform";
							this.activeTopPlatforms.Add (x);*/
							//this.activeTopPlatforms.Add (
							//	(GameObject)GameObject.Instantiate (this.NoPathPlatforms [platformType], new Vector3 (lastTopPlatPos.x + 14, 6.5f, 0), topRotate));
						}
					}
					break;
				case 3: //right
					nametag = rightPlatformTag; 
					
					float rightval = Random.value; //will it be path or no path
					//						Debug.Log ("Right side random val: " + rightval); 
					Vector3 lastRightPlatPos = this.activeRightPlatforms [this.activeRightPlatforms.Count - 1].transform.position;
					Quaternion rightRotate = this.activeRightPlatforms [this.activeRightPlatforms.Count - 1].transform.rotation; //Quaternion.AngleAxis (-90, Vector3.forward);
					if (rightval < .5) {
						if (np > 0) {
							//			Debug.Log ("np before adding platform: " +np);
							np = np - 1;
							CreateNoPathPlatform(nametag, rightPlatAdjustment, 0, lastRightPlatPos, rightRotate);
							/*
							//			Debug.Log("np after addition: " +np);														
							int platformType = ((int)Random.value) % this.NoPathPlatforms.Count; 
							//this.activeRightPlatforms.Add (
							//	(GameObject)GameObject.Instantiate (this.NoPathPlatforms [platformType], new Vector3 (lastRightPlatPos.x + 14f, 3f, -3.5f), rightRotate));
							GameObject x = (GameObject)GameObject.Instantiate (this.NoPathPlatforms [platformType], new Vector3 (lastRightPlatPos.x + 14f, 3f, -3.5f), rightRotate);
							x.tag = "RightPlatform";
							this.activeRightPlatforms.Add (x);*/
						} else {
							p = p - 1;
                            CreatePathPlatform(nametag, GrabPathPlatformRight(nametag, rightPlatAdjustment, 0, lastRightPlatPos, rightRotate));
							
							/*
							int platformType = ((int)Random.value) % this.PathPlatforms.Count; 
							//this.activeRightPlatforms.Add (
							//	(GameObject)GameObject.Instantiate (this.NoPathPlatforms [platformType], new Vector3 (lastRightPlatPos.x + 14f, 3f, -3.5f), rightRotate));
							GameObject x = (GameObject)GameObject.Instantiate (this.PathPlatforms [platformType], new Vector3 (lastRightPlatPos.x + 14f, 3f, -3.5f), rightRotate);
							x.tag = "RightPlatform";
							this.activeRightPlatforms.Add (x);*/
						}
					} else {
						if (p > 0) {
							p = p - 1;
                            CreatePathPlatform(nametag, GrabPathPlatformRight(nametag, rightPlatAdjustment, 0, lastRightPlatPos, rightRotate));
							/*
							int platformType = ((int)Random.value) % this.PathPlatforms.Count; 
							//this.activeRightPlatforms.Add (
							//	(GameObject)GameObject.Instantiate (this.NoPathPlatforms [platformType], new Vector3 (lastRightPlatPos.x + 14f, 3f, -3.5f), rightRotate));
							GameObject x = (GameObject)GameObject.Instantiate (this.PathPlatforms [platformType], new Vector3 (lastRightPlatPos.x + 14f, 3f, -3.5f), rightRotate);
							x.tag = "RightPlatform";
							this.activeRightPlatforms.Add (x);*/
						} else {
							//		Debug.Log ("np before adding platform: " +np);
							np = np - 1;
							CreateNoPathPlatform(nametag, rightPlatAdjustment, 0, lastRightPlatPos, rightRotate);
							/*
							//			Debug.Log("np after addition: " +np);														
							int platformType = ((int)Random.value) % this.NoPathPlatforms.Count; 
							//this.activeRightPlatforms.Add (
							//	(GameObject)GameObject.Instantiate (this.NoPathPlatforms [platformType], new Vector3 (lastRightPlatPos.x + 14f, 3f, -3.5f), rightRotate));
							GameObject x = (GameObject)GameObject.Instantiate (this.NoPathPlatforms [platformType], new Vector3 (lastRightPlatPos.x + 14f, 3f, -3.5f), rightRotate);
							x.tag = "RightPlatform";
							this.activeRightPlatforms.Add (x);*/
						}
					}
					break; 
				default:
					break; 
				}
			}
		}

	}
	
	
	void CreateNoPathPlatform (string tagname, float xpos , float ypos, Vector3 lastzVector, Quaternion rq)
	{
		int platformType = ((int)Random.value) % this.NoPathPlatforms.Count; 
		GameObject z = (GameObject)GameObject.Instantiate (this.NoPathPlatforms [platformType], new Vector3 (lastzVector.x, lastzVector.y, lastzVector.z + 14f), rq); //changed xpos and ypos
		z.gameObject.tag = tagname;
		z.transform.parent = this.transform;
		//z.transform.rotation = rq; //Possible reset it to fix problem?

		if(tagname.Equals(bottomPlatformTag))
			this.activeBottomPlatforms.Add (z);
		if (tagname.Equals(rightPlatformTag))
						this.activeRightPlatforms.Add (z);
		if(tagname.Equals(topPlatformTag))
			this.activeTopPlatforms.Add(z);
		if (tagname.Equals(leftPlatformTag))
						this.activeLeftPlatforms.Add (z);
	}
	
	void CreatePathPlatform( string tagname,/* float xpos, float ypos, Vector3 lastzVector, Quaternion rq,*/ GameObject x){
//		int platformType = ((int)Random.value) % this.PathPlatforms.Count; 
//		GameObject x = (GameObject)GameObject.Instantiate (this.PathPlatforms [platformType], new Vector3 (lastzVector.x, lastzVector.y, lastzVector.z + 14f), rq);
		x.gameObject.tag = tagname;
		x.transform.parent = this.transform;
		if(tagname.Equals(bottomPlatformTag))
			this.activeBottomPlatforms.Add (x);
		if (tagname.Equals(rightPlatformTag))
			this.activeRightPlatforms.Add (x);
		if(tagname.Equals(topPlatformTag))
			this.activeTopPlatforms.Add(x);
		if (tagname.Equals(leftPlatformTag))
			this.activeLeftPlatforms.Add (x);
	}
    public GameObject GrabPathPlatformLeft(string tagname, float xpos, float ypos, Vector3 lastzVector, Quaternion rq) 
    {
        int platformType = ((int)Random.value) % this.PathLeftPlatforms.Count;
        GameObject x = (GameObject)GameObject.Instantiate(this.PathLeftPlatforms[platformType], new Vector3(lastzVector.x, lastzVector.y, lastzVector.z + 14f), rq);
        return x; 
    }
    public GameObject GrabPathPlatformRight(string tagname, float xpos, float ypos, Vector3 lastzVector, Quaternion rq)
    {
        int platformType = ((int)Random.value) % this.PathRightPlatforms.Count;
        GameObject x = (GameObject)GameObject.Instantiate(this.PathRightPlatforms[platformType], new Vector3(lastzVector.x, lastzVector.y, lastzVector.z + 14f), rq);
        return x; 
    }

    public GameObject GrabPathPlatformTop(string tagname, float xpos, float ypos, Vector3 lastzVector, Quaternion rq)
    {
        int platformType = ((int)Random.value) % this.PathTopPlatforms.Count;
        GameObject x = (GameObject)GameObject.Instantiate(this.PathTopPlatforms[platformType], new Vector3(lastzVector.x, lastzVector.y, lastzVector.z + 14f), rq);
        return x ; 
    }

    public GameObject GrabPathPlatormBottom(string tagname, float xpos, float ypos, Vector3 lastzVector, Quaternion rq)
    {
        int platformType = ((int)Random.value) % this.PathBottomPlatforms.Count;
        GameObject x = (GameObject)GameObject.Instantiate(this.PathBottomPlatforms[platformType], new Vector3(lastzVector.x, lastzVector.y, lastzVector.z + 14f), rq);
        return x; 
    }
}
