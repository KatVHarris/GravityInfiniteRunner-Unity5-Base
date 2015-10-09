using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class GravityController : MonoBehaviour {
	public Vector3 force = Vector3.zero;
	/// <summary>
	/// Causes the force to be applied in the gameObject's local space.
	/// </summary>
	public bool relative = false;
	/// <summary>
		/// Causes the force to ignore mass and accelerate at the given force rate.
		/// </summary>
	public bool accelerate = false;
//	public Vector3 tor = Vector3.zero; 
//	public float sleepVelocity = 0.01f;

	float targetRotation = 90f;
	float rotation =0; 
	//private int cycles = 0;
	public float rotateSpeed = 500;
	bool isFlipping = false;
	public void FixedUpdate(){


	}

	void RotateObject ()
	{
		if (isFlipping) {
			Quaternion newRotation = Quaternion.AngleAxis (90, Vector3.left);
			transform.rotation = Quaternion.Slerp (transform.rotation, newRotation, .06f);
		}
		//isFlipping = true;
	}

	public void Update() {    
		RotateObject ();
		if (Input.GetKeyUp (KeyCode.Space)) {
						isFlipping = true; 
		}

		ForceMode mode = accelerate ? ForceMode.Acceleration : ForceMode.Force;
		if (relative) {
						GetComponent<Rigidbody>().AddRelativeForce (force, mode);
				} else {
						GetComponent<Rigidbody>().AddForce (force, mode);
				}
			/*
		float rotationAmt = rotateSpeed * Time.deltaTime;
		if (rotation == targetRotation)
			isFlipping = false;
		while(isFlipping && rotation != targetRotation){
			if(Mathf.Abs(rotation-targetRotation)<rotationAmt){
				transform.Rotate(rotation-targetRotation,0,0);
				rotation += rotationAmt; 
			}else{
				transform.Rotate(rotationAmt, 0, 0);
				rotation += rotationAmt; 
			}
		}
		*/
	/* if (rigidbody.velocity.sqrMagnitude < sleepVelocity * sleepVelocity) {
			++cycles;    
		}
		else {
			cycles = 0;
		}
		
		if (cycles > 3) {
			Object.Destroy(this);
			return;
	    }
		
		ForceMode mode = accelerate ? ForceMode.Acceleration : ForceMode.Force;
		if (relative) {
			rigidbody.AddRelativeForce(force, mode);
		        rigidbody.AddRelativeTorque(tor, mode);
		}
		else {
			rigidbody.AddForce(force, mode);
			rigidbody.AddTorque(tor, mode);
	   }*/
	}
}
