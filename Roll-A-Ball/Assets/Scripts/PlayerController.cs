using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public GameObject destruir;
	public GameObject ground;

	void Start()
	{
		ground = GameObject.Find ("Ground");
	}

	public float speed;

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal")*(true ? -1 : 1);
		float moveVertical = Input.GetAxis ("Vertical")*(true ? -1 : 1);

		Vector3 movement = new Vector3 (moveHorizontal,0.0f,moveVertical);

		Rigidbody body = GetComponent<Rigidbody> ();
		body.AddForce (movement * speed * Time.deltaTime * 2f);
	}

	void OnCollisionEnter(Collision c)
	{
		Physics.IgnoreCollision (ground.GetComponent<Collider>(),c.collider);
		if(c.gameObject.name.Contains("Cube"))
		{
			destruir = c.gameObject;
			//Destroy(c.gameObject);
		}
	}
}
