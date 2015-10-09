using UnityEngine;
using System.Collections;

public class ChangeMaterial : MonoBehaviour {

	public Material[] materials;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Restore(){
		GetComponent<Renderer>().sharedMaterial = materials[0];
	}

	public void ChangeColor(){
		GetComponent<Renderer>().sharedMaterial = materials[1];
	}
}
