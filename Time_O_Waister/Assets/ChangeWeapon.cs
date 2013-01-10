using UnityEngine;
using System.Collections;

public class ChangeWeapon : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
			   		
	
	}
	void OnCollision(Collision c)
	{
		GameObject gos = GameObject.Find("Sphere");
		
		if(c.gameObject.name == "Hand_L" )
		{			
		gos.BroadcastMessage("ChangeWeapon",0);
		}
		else if(c.gameObject.name == "Hand_R" )
		{
		gos.BroadcastMessage("ChangeWeapon",0);
		}
	}
}
