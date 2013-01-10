using UnityEngine;
using System.Collections;

public class CheckPuzzle : MonoBehaviour {
	
		int[] cubesFace = new int[9];
		int count = 0;
		private GameObject g ;
	// Use this for initialization
	void Start () {
		
	 g =GameObject.Find("YouWin");
	}
	void Rotate(int i)
	{
		cubesFace[i /10-1] = i%10;
	}
	
	// Update is called once per frame
	void Update () {

		g.guiText.enabled = false;
		for(int i = 1; i < 9 ; i++)
		{			
			 if(cubesFace[i] != cubesFace[i-1] ) 
				return;
			else  if(cubesFace[i] == cubesFace[i-1]  && i == 8)
			{
						g.guiText.enabled = true;
						ResetWall();
			}
		}				
	
	}
	void ResetWall()
	{
		GameObject cube;
		for(int i = 1; i < 10 ; i ++)
		{
			cube = GameObject.Find("Cube"+i);
			cube.BroadcastMessage("Reset");
		}
	}
}