using UnityEngine;
using System.Collections;

public class RotateCube : MonoBehaviour {
	
		public int cubeID = 1;
		public int faceID1 = 1;
		public int faceID2 = 2;
		public int faceID3 = 3;
		public int faceID4 = 4;
		public int faceID5 = 5;
		public int faceID6 = 6;
	
		private int initfaceID1 = 1;
		private int initfaceID2 = 2;
		private int initfaceID3 = 3;
		private int initfaceID4 = 4;
		private int initfaceID5 = 5;
		private int initfaceID6 = 6;
		private Quaternion q;
	
		private Vector3 up;
		private Vector3 forward;
		private Vector3 right;
		private GameObject gos;
	
	// Use this for initialization
	void Start () {
		q = transform.rotation;
		initfaceID1 = faceID1 ;
		initfaceID2 = faceID2 ;
		initfaceID3 = faceID3 ;
		initfaceID4 = faceID4 ;
		initfaceID5 = faceID5 ;
		initfaceID6 = faceID6 ;
		
		up = -this.transform.up;
		forward = this.transform.right;
		right = this.transform.forward;
		gos = GameObject.Find("Wall");
	
	}
	
	// Update is called once per frame
	void Update () {
		
			
			gos.BroadcastMessage("Rotate",cubeID*10+faceID1);
	}
	
	void OnCollisionEnter(Collision c)
	{
		int i = 0;
		Vector3 z;
		if(c.gameObject.name == "Fireb(Clone)")
		{
			transform.Rotate(90 * right);
			i = faceID1;
			faceID1 = faceID4;
			faceID4 = faceID3;
			faceID3 = faceID2;
			faceID2 = i;
			z =up;
			up = -forward;
			forward = z;
		}
		if(c.gameObject.name == "Waterb(Clone)")
		{
			transform.Rotate(90 * up);	
			i = faceID1;
			faceID1 = faceID5;
			faceID5 = faceID3;
			faceID3 = faceID6;
			faceID6 = i;
			z = forward;
			forward = -right;
			right = z;
		}

	}
	void Reset()
	{
		transform.rotation = q;
		up = -this.transform.up;
		forward = this.transform.right;
		right = this.transform.forward;
		gos = GameObject.Find("Wall");
		faceID1 = initfaceID1 ;
		faceID2 = initfaceID2 ;
		faceID3 = initfaceID3 ;
		faceID4 = initfaceID4 ;
		faceID5 = initfaceID5 ;
		faceID6 = initfaceID6 ;

		
	}
}
