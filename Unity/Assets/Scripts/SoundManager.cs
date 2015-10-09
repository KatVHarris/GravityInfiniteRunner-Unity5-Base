using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    public AudioSource musicSource;
    public static SoundManager instanceSM = null; 


	// Use this for initialization
	void Awake () {
        Debug.Log("Is in Awake");
        //if (instanceSM = null)
        //    instanceSM = this;
        //else
        //    Destroy(gameObject);

        //DontDestroyOnLoad(gameObject);
	}



	// Update is called once per frame
	void Update () {
        if (GetComponent<AudioSource>().isPlaying)
        {
            //Debug.Log("Is Playing Music");
        }
        else
        {
            Debug.Log("Sound is messed up");
            GetComponent<AudioSource>().Play(); 
        }
	}
}
