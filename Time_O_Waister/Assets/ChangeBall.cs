using UnityEngine;
using System.Collections;

public class ChangeBall : MonoBehaviour {

	public int ballType = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision c)
	{
		GameObject g = GameObject.Find("Sphere");
		if(c.gameObject.name == "Sphere2")
		{
			g.BroadcastMessage("ChangeWeapon",ballType);
		}
	}
}
