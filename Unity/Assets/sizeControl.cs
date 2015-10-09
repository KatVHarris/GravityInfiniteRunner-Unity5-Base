using UnityEngine;
using System.Collections;

public class sizeControl : MonoBehaviour {
	private Vector3 totalSize;
	int count = 5;
	// Use this for initialization
	void Start () {
		//totalSize = transform.renderer.bounds.size;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.H)){
			Debug.Log("Pressed");
			if(GetComponent<Rigidbody>().transform.localScale.magnitude > .5f)
				GetComponent<Rigidbody>().transform.localScale -= Vector3.one * 1.2f * Time.deltaTime;
				
		}
		if(Input.GetKey(KeyCode.L)){
			if(GetComponent<Rigidbody>().transform.localScale.magnitude < 10f)
				GetComponent<Rigidbody>().transform.localScale += Vector3.one * 1.2f * Time.deltaTime;
		}
	}
}
