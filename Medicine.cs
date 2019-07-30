using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medicine : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(PlayerHealth.currentHealth >= 1950)
            {
                PlayerHealth.currentHealth = 2000;
            }

            else PlayerHealth.currentHealth += 50;
        }
    }
}
