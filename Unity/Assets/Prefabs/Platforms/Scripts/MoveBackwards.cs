using UnityEngine;
using System.Collections;

public class MoveBackwards : MonoBehaviour {
	public float backspeed = 3.0f;

	
	// Update is called once per frame
	void Update () {
        Move();
	}
   
    void Move()
    {
        transform.Translate(Vector3.back * Time.deltaTime * backspeed);
    }


}
