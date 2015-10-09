using UnityEngine;
using System.Collections;

public class SimpleRotator : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    public Transform target;
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * 30f);
            //Vector3 relativePos = target.position - transform.position;
            //Quaternion rotation = Quaternion.LookRotation(relativePos);
            //transform.rotation = rotation;
        }

    }
}

