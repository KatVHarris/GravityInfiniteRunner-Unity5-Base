using UnityEngine;
using System.Collections;
using System;

public class Shoot : MonoBehaviour {

	private float nextFire;
	public float fireRate = 1f;
	public Transform shotSpawn;
	public GameObject shot; 
	GameObject currentGo; 
	private GameObject lastTarget;
	private GameObject Target;
	private GameObject mainTarget;

	private EffectSettings effectSettings;
	GameObject go;

	private bool isDay, isHomingMove;
	private float prefabSpeed = 25f;
	private bool isReadyEffect= true; 
	private bool isReadyDefaulBall;
	Color originalMaterial;

	void Start(){
		go = GameObject.Find ("ShotSpawner");
		mainTarget = GameObject.Find ("TargetObject");
		lastTarget = mainTarget;
		originalMaterial = mainTarget.GetComponent<Renderer>().material.color ; 


		//Get shot from inventory...
		//InstanceEffect(transform.position);

	}
	
	// Update is called once per frame
	void Update () {


		GetTarget();
	    if (Input.GetKeyUp(KeyCode.M) && Time.time > nextFire)
        {

			//Get shot from inventory...
			InstanceEffect(go.transform.position);
            nextFire = Time.time + fireRate;
            //Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			//InstanceEffect(transform.position);
			if (isReadyEffect) {
				isReadyEffect = false;
				currentGo.SetActive(true);
			}

        }
        
	}


	private void GetTarget(){
		RaycastHit hit;
		if (Physics.Raycast(transform.position, transform.forward, out hit, 40))
		{

			Collider target = hit.collider; // What did I hit?
			float distance = hit.distance; // How far out?
			Vector3 location = hit.point; // Where did I make impact?

			Target = hit.collider.gameObject; // What's the GameObject?
			if(hit.collider.tag == "TargetObject"){
				Debug.Log("MainTarget");
			}
			if(lastTarget != Target){
				if(hit.collider.tag == "Enemy"){

					//paint red
					//Call change color on object
					Target.gameObject.GetComponent<ChangeMaterial>().ChangeColor();
					//originalMaterial = hit.transform.renderer.material.color;
					//hit.transform.renderer.material.color = Color.Lerp(hit.transform.renderer.material.color, Color.red, 0.5f);
				}
				else{
					Target = mainTarget;
					//change color back
					//call restore on last object
					//lastTarget.renderer.material.color = originalMaterial;
					if(lastTarget.tag == "Enemy")
						lastTarget.gameObject.GetComponent<ChangeMaterial>().Restore();
				}
			}
			lastTarget = Target; 
		}
	}

	private void InstanceEffect(Vector3 pos)
	{
		currentGo = Instantiate(shot, pos, shot.transform.rotation) as GameObject;
		effectSettings = currentGo.GetComponent<EffectSettings>();
		effectSettings.Target = Target;
		if (isHomingMove) effectSettings.IsHomingMove = isHomingMove;
		prefabSpeed = effectSettings.MoveSpeed;
		effectSettings.EffectDeactivated+=effectSettings_EffectDeactivated;
		currentGo.transform.parent = go.transform;//transform;
		//effectSettings.CollisionEnter += (n, e) => { Debug.Log(e.Hit.transform.name); };
	}

	void effectSettings_EffectDeactivated(object sender, EventArgs e)
	{
		currentGo.transform.position = transform.position;// GetInstancePosition(GuiStats[current]);
		isReadyEffect = true;
	}
}




