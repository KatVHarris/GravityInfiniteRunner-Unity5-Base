using UnityEngine;
using System.Collections;

public class ColliderScript : MonoBehaviour {
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			Debug.Log("Collided!");
		}
		if (other.gameObject.transform.parent) {
						Destroy (other.gameObject.transform.parent.gameObject);
				} else {
						Destroy (other.gameObject);
				}
	}
}
