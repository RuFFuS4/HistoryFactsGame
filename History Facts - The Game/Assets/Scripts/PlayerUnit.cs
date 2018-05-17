using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

//A PlayerUnit is a unit controlled by a player
// This could be a character in a FPS, a zerling in a RTS or a scout in a TBS

public class PlayerUnit : NetworkBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        //How do I verify that I am allowed to mess around with this object?
        if (hasAuthority == false)
        {
            return;
        }
        //PRUEBAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
        if (Input.touchCount > 0)
        {
            this.transform.Translate(0,1,0);
            
        }
        //This function runs on ALL PlayerUnits -- not just the ones that I own.
    }
}
