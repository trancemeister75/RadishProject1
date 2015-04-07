using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {

	public Vector3 spawnLocation;
	public float mySpeed;
	public int count;

	void Start () {
		StartCoroutine ("CreateCubes");
	}

	void FixedUpdate () {

	}

	IEnumerator CreateCubes() {
		while(count <= 70){
			spawnLocation = new Vector3(Random.Range(-1.5f,1.5f) * 10, 0.5f, Random.Range(-1.5f,1.5f) * 10);
			GameObject randomObject = (GameObject)Instantiate(GameObject.CreatePrimitive(PrimitiveType.Sphere), spawnLocation, Quaternion.identity);
			randomObject.transform.localScale += new Vector3(1.5f,1.5f,1.5f);
			randomObject.AddComponent<Rigidbody>();;
			float delay = 0.5f;
			yield return new WaitForSeconds (delay);
				count++;
			randomObject.name = "Cube"+count;
		}
	}
}
