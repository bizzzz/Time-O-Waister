using UnityEngine;
using System.Collections;

public class lightFollow : MonoBehaviour {


	// Use this for initialization
	void Start () {
		transform.Translate(-2000,-2000,-2000);
	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject g = GameObject.Find("Waterb(Clone)");
		if(g != null)
		transform.position = g.transform.position;
		else
					transform.Translate(-2000,-2000,-2000);
	}
}
