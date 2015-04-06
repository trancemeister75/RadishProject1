using UnityEngine;
using System.Collections;

public class ChaseController : MonoBehaviour
{
	//public GameObject cube;
	public float interpVelocity;
	public Vector3 newPosition;
	public Vector3 offset;
	public Rigidbody body;
	// Use this for initialization
	void Start ()
	{
		//player = GameObject.Find ("Player");
		body = GetComponent<Rigidbody> ();
		//cube = GetComponent<GameObject> ();
		//StartCoroutine ("Chase");
	}

	void FixedUpdate()
	{
			//newPosition = new Vector3(Random.Range(-10f,10f) * 50, 0.5f, Random.Range(-10f,10f) * 50);
			body.MovePosition(transform.position+transform.forward*Time.deltaTime);
	}
}

