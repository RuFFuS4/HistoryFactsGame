using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class PlayerConnectionObject : NetworkBehaviour {

	// Use this for initialization
	void Start () {
        //Is this actually my own local PlayerConnectionObject?
        if (isLocalPlayer == false) {
            //This object belongs to another player.
            return;
        }
        //Since the PlayerConnectionObject is invisible and not part of the world, give me something physical to move around!
        //Instantiate() only creates an object on the LOCAL COMPUTER even if it has a NetworkIdentity is still will NOT exist on the network (and therefore not on any other client)
        //UNLESS NetworkServer.Spawn() is called on this object.

        //Instantiate(PlayerUnitPrefab);

        //Command (politely) the server to SPAWN out unit
        CmdSpawnMyUnit();
	}
    public GameObject PlayerUnitPrefab;
	// Update is called once per frame
	void Update () {
       /* if (isLocalPlayer == false)
        {
            //This object belongs to another player.
            return;
        }

        //PRUEBAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
        if (Input.touchCount >0) {
            CmdMoveup();
        }*/
    }

    /*COMMANDS*/
    //Commands are special functions that ONLY get executed on the server.
    /*ALL commands should have the word Cmd*/
    GameObject myPlayerUnit;

    [Command]
    void CmdSpawnMyUnit() {
        //We are guaranteed to be on the server rigth now.
        GameObject go = Instantiate(PlayerUnitPrefab);
        myPlayerUnit = go;
        /*go.GetComponent<NetworkIdentity>().AssignClientAuthority(connectionToClient);*/
        //Now that the object exist on the server, propagate it to all the clients (and also wire up the NetworkIdentity)
        NetworkServer.SpawnWithClientAuthority(go,connectionToClient);
    }

    //PRUEBAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
    [Command]
    void CmdMoveup() {
        if (myPlayerUnit == null) {
            return;
        }
        myPlayerUnit.transform.Translate(0,1,0);
    }
}
