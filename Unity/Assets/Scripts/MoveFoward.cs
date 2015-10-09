using UnityEngine;
using System.Collections;

public class MoveFoward : MonoBehaviour {
	public float forwardspeed = 6.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.forward * Time.deltaTime * forwardspeed);
	}
}
