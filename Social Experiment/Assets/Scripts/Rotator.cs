﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Rotator : NetworkBehaviour {

	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}


}
