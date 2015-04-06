using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	void Start()
	{

	}

	public float speed;

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal")*(true ? -1 : 1);
		float moveVertical = Input.GetAxis ("Vertical")*(true ? -1 : 1);

		Vector3 movement = new Vector3 (moveHorizontal,0.0f,moveVertical);

		Rigidbody body = GetComponent<Rigidbody> ();
		body.AddForce (movement * speed * Time.deltaTime);
	}

	void OnCollisionEnter(Collision c)
	{
		if(c.gameObject.name == "Player" && c.gameObject.name != "Ground")
		{
			Destroy (c.gameObject);
		}
	}
}
