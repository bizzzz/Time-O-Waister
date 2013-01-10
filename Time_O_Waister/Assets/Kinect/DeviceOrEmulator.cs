using UnityEngine;
using System.Collections;

public class DeviceOrEmulator : MonoBehaviour {
	
	public KinectSensor device;
	public KinectEmulator emulator;
	public int useEmulator = 0;
	
	// Use this for initialization
	void Start () {
		if(useEmulator == 1){
			
			emulator.enabled = true;
		}
		else
			device.enabled = true;
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public Kinect.KinectInterface getKinect() {
		
		if(useEmulator == 1){			
			return emulator;
		}
		else
			return device;		
	}
}
