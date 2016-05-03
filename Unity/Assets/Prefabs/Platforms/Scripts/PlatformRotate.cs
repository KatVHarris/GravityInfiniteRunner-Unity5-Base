using UnityEngine;
using System.Collections;

public class PlatformRotate : MonoBehaviour {
	public bool rotating = false; 
	public float rotationAngle  = 0; 
	private Quaternion curAngle; 
	public float targetAngle = 0f; 
	const float rotationAmt = 1.5f; 
	public float rDistance = 1.0f; 
	public float rSpeed = 1.0f; 
	private float lastAngle = 0.0f; 
	private float angle = 0.0f; 
	// Use this for initialization
	void Start () {
	
	}
	int degree = 0; 


	//No Coroutine too fast
	/*
	void Update (){
		if (Input.GetKeyUp (KeyCode.H)) {
			curAngle = transform.localRotation;
			targetAngle = 90.0f;
			Rotate();
		}
	}

	protected void Rotate(){
		float step = rSpeed * Time.deltaTime; 
		transform.RotateAround (Vector3.zero, Vector3.forward, targetAngle); 
		//float orbitCircumfrance = 2F * rDistance *
	}

*/

	//Using Co Routines
	int count = 1; 
	int countRight = 1;
	int countLeft = 1; 
	int countFlip = 1; 
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.Q)){


		//	angle = getNextLeft(angle);
		//	RotatePlatform(angle);
			Debug.Log("ANGLE: "+ angle);

			
			if(!rotating) {
				//angle = getNextLeft(angle);
				angle = getNextLeftAngle(angle);
				StartCoroutine(RotateMe(angle));
			}


		
		}

		if(Input.GetKeyUp(KeyCode.E)){
			
			 
			Debug.Log("rotating " + rotating);
			//angle = getNextRight(angle);

			//RotatePlatform(angle);


			Debug.Log("ANGLE: "+ angle);
			if(!rotating) {
				angle = getNextRightAngle(angle);
				StartCoroutine(RotateMe(angle));
			}

		}

		if(Input.GetKeyUp("space")){
			
			Debug.Log("rotating " + rotating );
			if(!rotating) {
				angle = getNextFlip(angle); 
				Debug.Log("FLIP ANGLE: " + angle);

				//RotatePlatform(angle);
				StartCoroutine(FlipMe(angle));
			}
		}
	}

	float getNextLeft (float oAngle)
	{
		if (oAngle == 270) {
						oAngle = 0;
			return oAngle; 
				} else {
						oAngle = oAngle + 90; 
			return oAngle; 
				}
	}

	float getNextLeftAngle (float oAngle){
		oAngle = oAngle + 90; 
		return oAngle; 
	}

	float getNextFlip (float oAngle)
	{
		oAngle = oAngle + 180; 
		return oAngle; 
	}
	
	float getNextRightAngle (float oAngle)
	{
		oAngle = oAngle - 90; 
		return oAngle; 
	}

	float getNextRight (float oAngle)
	{
		if (oAngle == 0) {
			oAngle = 270;
			return oAngle; 
		} else {
			oAngle = oAngle - 90; 
			return oAngle; 
		}
	}



	private void RotatePlatform(float nextAngle){
		transform.rotation = Quaternion.AngleAxis(nextAngle, Vector3.forward);	
		rotating = false; 
	}

	IEnumerator FlipMe (float nextstep)
	{
		rotating = true; 
		float step = 232 * Time.smoothDeltaTime;
		Quaternion fromAngle = transform.rotation;
		Quaternion newRotation = Quaternion.Euler (new Vector3(0, 0, nextstep));	

		while (transform.rotation != newRotation) {//the original angle from the input key dot with 90 degree < !=  0 
			transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, step);
				yield return null;
		}
		rotating = false; 
		Debug.Log ("Rotate Done: " + rotating);	
			
		}

	IEnumerator RotateMe(float nextstep) {
		//if (rotating)		return; 
		rotating = true; 
		float step = 500 * Time.smoothDeltaTime;
		Quaternion fromAngle = transform.rotation;
		Quaternion newRotation = Quaternion.Euler (new Vector3(0, 0, nextstep));	
		while(transform.rotation != newRotation){//the original angle from the input key dot with 90 degree < !=  0 
			Debug.Log("z coordinates: " + transform.rotation.z);
			transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, step);//newRotation;
			yield return null;

		}
		rotating = false; 
		Debug.Log ("Rotate Done: " + rotating);
	}


}
