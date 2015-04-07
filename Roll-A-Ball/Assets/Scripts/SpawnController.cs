using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {

	public Vector3 spawnLocation;
	//public GameObject myCube;	
	public float mySpeed;
	public int count;

	// Use this for initialization
	void Start () {
		//myCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		//myCube.name = "Cube";
		StartCoroutine ("CreateCubes");
	}
	
	// Update is called once per frame
	void Update () {

	}

	IEnumerator CreateCubes() {
		while(count <= 100){
			spawnLocation = new Vector3(Random.Range(-0.8f,0.8f) * 10, 1.5f, Random.Range(-0.8f,0.8f) * 10);
			GameObject randomObject = (GameObject)Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube), spawnLocation, Quaternion.identity);
			randomObject.AddComponent<Rigidbody>();;
			float delay = 0.5f;
			yield return new WaitForSeconds (delay);
				count++;
			randomObject.name = "Cube"+count;
		}
	}
}
