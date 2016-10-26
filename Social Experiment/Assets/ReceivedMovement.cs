using UnityEngine;
using System.Collections;

public class ReceivedMovement : MonoBehaviour {

	Vector3 newPosition;
	public float speed;
	public float walkRange;

	public GameObject graphics;

	// Use this for initialization
	void Start () {

		newPosition = this.transform.position;

	
	}
	
	// Update is called once per frame
	void Update () {

		if (Vector3.Distance (newPosition, this.transform.position) > walkRange) {
		
			this.transform.position = Vector3.MoveTowards (this.transform.position, newPosition, speed * Time.deltaTime);
			Quaternion transRot = Quaternion.LookRotation (newPosition - this.transform.position, Vector3.up);
			graphics.transform.rotation = Quaternion.Slerp (transRot, graphics.transform.rotation, 0.2f);
		}
	}

	[PunRPC]
	public void ReceivedMove(Vector3 movePos){
	
		newPosition = movePos;
	
	}
}
