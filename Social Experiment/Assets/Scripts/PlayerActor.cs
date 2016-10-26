using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnitySampleAssets.CrossPlatformInput;

public class PlayerActor : NetworkBehaviour
{

    [SyncVar]
    public float speed;
    public float rotationSpeed;
	public GameObject bulletPrefab = null;
	public Transform bulletSpawn = null;


  //  public Text countText;
   // public Text winText;

    private Rigidbody rb;
  //  [SyncVar]
  //  private int count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
		ClientScene.RegisterPrefab (bulletPrefab);
       // count = 0;
     //   SetText();
     //   winText.text = "";
    }

    void FixedUpdate()
    {

        float translation = CrossPlatformInputManager.GetAxis("Vertical") * speed;
        float rotation = CrossPlatformInputManager.GetAxis("Horizontal") * rotationSpeed;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);
        
    }

	private void Update(){
		if (CrossPlatformInputManager.GetButtonDown("Jump"))
			Cmd_Shoot();
	}


	[Command]
	public void Cmd_Shoot()
	{
		// create server-side instance
		GameObject obj = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
		// setup bullet component
		Bullet bullet = obj.GetComponent<Bullet>();
		bullet.velocity = transform.forward;
		// destroy after 2 secs
		Destroy(obj, 2.0f);
		// spawn on the clients
		NetworkServer.Spawn(obj);
	}

	public override void OnStartLocalPlayer()
	{
		base.OnStartLocalPlayer();

		// you can use this function to do things like create camera, audio listeners, etc.
		// so things which has to be done only for our player
	}



 //   void OnTriggerEnter(Collider other)
  //  {
 //       if (other.gameObject.CompareTag("Pick Up"))
   //     {
   //         other.gameObject.SetActive(false);
   //         count = count + 1;
        //    SetText();
   //     }
//}

  /*  void SetText()
    {
        countText.text = "Count " + count.ToString();
        if (count >= 12)
        {
            winText.text = "You win!";
        }
    } */
}