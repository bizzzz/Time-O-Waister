using UnityEngine;
using System.Collections;

public class ratateball : MonoBehaviour {
	
	public int val;
	private bool activate = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(val == 1 && activate)
		transform.Rotate(2,0,0);
		else if(val == 2 && activate)
		transform.Rotate(0,2,0);
		else if(val == 3)
		transform.Rotate(0,-5,0);
		else if(activate)
		transform.Rotate(10,10,10);

	
	}
		void OnCollisionEnter(Collision c)
	{
		//activate = true;
	}
}
