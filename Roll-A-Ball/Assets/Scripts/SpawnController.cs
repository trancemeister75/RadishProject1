using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {

	public Vector3 spawnLocation;
	public GameObject myCube;	
	public float mySpeed;
	public int count;

	// Use this for initialization
	void Start () {
		myCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		StartCoroutine ("CreateCubes");
	}
	
	// Update is called once per frame
	void Update () {

	}

	IEnumerator CreateCubes() {
		while(count <= 20){
			spawnLocation = new Vector3(Random.Range(-0.8f,0.8f) * 10, 1.5f, Random.Range(-0.8f,0.8f) * 10);
			GameObject randomObject = (GameObject)Instantiate(myCube, spawnLocation, Quaternion.identity);
			randomObject.AddComponent<Rigidbody>();
			//MeshRenderer rend = randomObject.GetComponent<MeshRenderer>();
			//rend.material = Resources.Load("Enemy") as Material;
			float delay = 0.5f;
			yield return new WaitForSeconds (delay);
				count++;
		}
	}
	
}
