using UnityEngine;
using System.Collections;

public class ChaseController : MonoBehaviour
{
	public GameObject player;
	public float interpVelocity;
	public Vector3 newPosition;
	public Vector3 offset;
	
	// Use this for initialization
	void Start ()
	{
		player = GameObject.Find ("Player");
		StartCoroutine ("Chase");
	}

	IEnumerator Chase()
	{
		while (true)
		{
			newPosition = new Vector3(Random.Range(-10f,10f) * 50, 0.5f, Random.Range(-10f,10f) * 50);
			transform.position = Vector3.MoveTowards( transform.position, newPosition, 1f*Time.deltaTime);
			
			// If the object has arrived, stop the coroutine
			if (transform.position == newPosition)
			{
				yield break;
			}
			
			// Otherwise, continue next frame
			yield return null;
		}
	}
}

