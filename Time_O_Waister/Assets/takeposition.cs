using UnityEngine;
using System.Collections;

public class takeposition : MonoBehaviour {

	public Rigidbody r;

	
	// Update is called once per frame
		// Use this for initialization
	void Start () {
		transform.Translate(-2000,-2000,-2000);
	
	}
	
	// Update is called once per frame
	void Update () {
		

		transform.position = r.transform.position;

	}
}

