using UnityEngine;
using System.Collections;

public class PlatformCollider : MonoBehaviour {

    private PlayerHealthController playerHealth;       // Reference to the player's health.
    GameObject player;                                        // Use this for initialization

    public int attackDamage = 20; 
    
    void Awake () { //Do this once in awake so you can improce efficency
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealthController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player && playerHealth.currentHealth>0 )
        {
            playerHealth.TakeDamage(attackDamage);
        }

    }
}
