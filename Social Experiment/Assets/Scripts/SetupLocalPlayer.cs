using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System;

public class SetupLocalPlayer : NetworkBehaviour {

    [SyncVar]
    public string pname = "player";

    void OnGUI()
    {
        if (isLocalPlayer)
        {
            pname = GUI.TextField(new Rect(25, Screen.height - 40, 100, 30), pname);
            if(GUI.Button(new Rect(130,Screen.height - 40, 80, 30), "Change"))
            {
                CmdChangeName(pname);
            }
        }
        
    }

    [Command]
    private void CmdChangeName(string newName)
    {
        pname = newName;
    }

    // Use this for initialization
    void Start () {
        if (isLocalPlayer)
        {
            GetComponent<PlayerActor>().enabled = false;
			SmoothCameraFollow.target = this.transform;
        }
	}

    void Update()
    {
        
            this.GetComponentInChildren<TextMesh>().text = pname;
        
    }
	
}
