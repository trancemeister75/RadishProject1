using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public GameObject destruir;
	public GameObject ground;
	public int count;
	public GameObject player;
	public float timeLeft;
	Vector3 movement;
	//accelerometer
	private Vector3 zeroAc;
	private Vector3 curAc;
	private float sensH = 20;
	private float sensV = 20;
	private float smooth = 0.5f;
	private float GetAxisH = 0;
	private float GetAxisV = 0;
	public float speedAc = 15;
	public Rigidbody body;

	void Start()
	{
		ground = GameObject.Find ("Ground");
		player = GameObject.Find ("Player");
		body = GetComponent<Rigidbody> ();
		ResetAxes();
	}

	public float speed;

	void FixedUpdate()
	{
		//Si el input es desktop
		if (SystemInfo.deviceType == DeviceType.Desktop) {
			float moveHorizontal = Input.GetAxis ("Horizontal")*(true ? -1 : 1);
			float moveVertical = Input.GetAxis ("Vertical")*(true ? -1 : 1);
			movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
			body.AddForce (movement * speed * Time.deltaTime * 2.1f);
		}
		//Si el input es Movil
		else if(SystemInfo.deviceType == DeviceType.Handheld){
			//get input by accelerometer
			curAc = Vector3.Lerp(curAc, Input.acceleration-zeroAc, Time.deltaTime/smooth);
			GetAxisV = Mathf.Clamp(curAc.y * sensV, -1, 1);
			GetAxisH = Mathf.Clamp(curAc.x * sensH, -1, 1);
			// now use GetAxisV and GetAxisH instead of Input.GetAxis vertical and horizontal
			// If the horizontal and vertical directions are swapped, swap curAc.y and curAc.x
			// in the above equations. If some axis is going in the wrong direction, invert the
			// signal (use -curAc.x or -curAc.y)
			
			movement = new Vector3 (GetAxisH, 0.0f, GetAxisV);
			
			body.AddForce(movement * speedAc);
		}


	}

	//accelerometer
	void ResetAxes(){
		zeroAc = Input.acceleration;
		curAc = Vector3.zero;
	}

	void OnCollisionEnter(Collision c)
	{
		Physics.IgnoreCollision (ground.GetComponent<Collider>(),c.collider);
		if(c.gameObject.name.Contains("Cube"))
		{
			destruir = c.gameObject;
			count++;
			Destroy(c.collider);
		}
	}

	void OnGUI()
	{
		GUI.Label (new Rect(1,1,1,1),"");
		GUILayout.Label ("Score: "+count);
		GUILayout.Label ("\nTime: "+timeLeft);
	}

	void Update()
	{
		timeLeft -= Time.deltaTime;
		if ( timeLeft < 0 )
		{
			GameOver();
		}
	}

	void GameOver()
	{
		foreach (GameObject o in Object.FindObjectsOfType<GameObject>()) {
			Destroy(o);
		}
	}
}
