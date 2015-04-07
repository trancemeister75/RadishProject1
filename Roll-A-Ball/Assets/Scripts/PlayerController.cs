using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public GameObject destruir;
	public GameObject ground;
	//public GUIText text;
	public int count;
	public GameObject player;
	public float timeLeft;

	void Start()
	{
		ground = GameObject.Find ("Ground");
		player = GameObject.Find ("Player");
	}

	public float speed;

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal")*(true ? -1 : 1);
		float moveVertical = Input.GetAxis ("Vertical")*(true ? -1 : 1);

		Vector3 movement = new Vector3 (moveHorizontal,0.0f,moveVertical);

		Rigidbody body = GetComponent<Rigidbody> ();
		body.AddForce (movement * speed * Time.deltaTime * 2.1f);
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
