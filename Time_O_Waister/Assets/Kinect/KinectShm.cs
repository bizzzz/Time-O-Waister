using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using UnityEngine;
using Kinect;
using KinectData;
using de.dailab.interprocess.shm;


public class KinectShm : MonoBehaviour, KinectInterface {
	
	
	private DataReader skeletonReader ;
	byte[] readBytes = new byte[1422 + 32];
	private int sizeOfBytesToRead = 1422 + 32;
    private int[] trackedUsersIDs  = new int[6];
    private byte nrTrackedUsers = 0;	
	private NuiSkeletonData[] SkeletonData = new NuiSkeletonData[6];
	private NuiSkeletonFrame skeleton = new NuiSkeletonFrame();
	private bool pollskeleton = false;
	private KinectData.Skeletons skeletons = new KinectData.Skeletons(0) ;
	private bool  updatedSkeleton = true;
	private NuiTransformSmoothParameters smoothParameters = new NuiTransformSmoothParameters();
	private bool newSkeleton = false;
	
	/// <summary>
	/// how high (in meters) off the ground is the sensor
	/// </summary>
	public float sensorHeight = 1;
	/// <summary>
	/// where (relative to the ground directly under the sensor) should the kinect register as 0,0,0
	/// </summary>
	public Vector3 kinectCenter = new Vector3(0,0,2);
	/// <summary>
	/// what point (relative to kinectCenter) should the sensor look at
	/// </summary>
	public Vector4 lookAt = new Vector4(0,1,0,0);
		/// <summary>
	/// Variables used to pass to smoothing function. Values are set to default based on Action in Motion's Research
	/// </summary>
	public float smoothing =0.5f;	
	public float correction=0.5f;
	public float prediction=0.5f;
	public float jitterRadius=0.05f;
	public float maxDeviationRadius=0.04f;
	//public bool enableNearMode = false;

		void Start () 
	{
		try {
	     	skeletonReader = new DataReader("Skeleton");
			Debug.Log("Shm skeleton reader created.");
		} catch ( Exception exc ) {
			Debug.Log( "Exception: " + exc.Message );
		}
	}
	
	
	void Update ()
	{
		this.pollskeleton = false;

		
           uint numberOfReadBytes = skeletonReader.readData(readBytes, (uint)sizeOfBytesToRead, DataRequest.Type.NEWEST_AVAILABLE);

		if(numberOfReadBytes != 0 )
		{
		newSkeleton = false;
		updatedSkeleton = false;
		this.pollskeleton = true;
		pollskeleton = true;
		skeletons = new Skeletons(readBytes);
		skeleton.dwFrameNumber = (uint)skeletons.frameNumber;
		skeleton.liTimeStamp = skeletons.timeStamp;
		skeleton.vFloorClipPlane = new Vector4(skeletons.floorClipPlaneX,skeletons.floorClipPlaneY,skeletons.floorClipPlaneZ,skeletons.floorClipPlaneW);
		skeleton.vNormalToGravity = new Vector4(0,0,0,0);
		skeleton.dwFlags = 0;
			
		int index = 0;
		
		skeleton.SkeletonData = new NuiSkeletonData[6];
		NuiSkeletonData sd = new NuiSkeletonData();
			
		for(int i1 = 0;i1< 6;i1++)
		{
		
			sd.SkeletonPositions = new Vector4[20];
			sd.eSkeletonPositionTrackingState = new NuiSkeletonPositionTrackingState[20];
			sd.dwTrackingID = (uint)BitConverter.ToInt32(skeletons.skeletonsBytes,index);
			index += sizeof(Int32);
			byte trackingMode = skeletons.skeletonsBytes[index++];
				if(trackingMode == 0)
				{
			sd.eTrackingState = Kinect.NuiSkeletonTrackingState.PositionOnly;
				}
			else if(trackingMode == 1)
				{
				sd.eTrackingState =  Kinect.NuiSkeletonTrackingState.SkeletonTracked;

				}
			else if(trackingMode == 2)
				{
				sd.eTrackingState =  Kinect.NuiSkeletonTrackingState.NotTracked;
				}
			sd.Position.x = BitConverter.ToSingle(skeletons.skeletonsBytes,index);
			index+=sizeof(float);
			sd.Position.y = BitConverter.ToSingle(skeletons.skeletonsBytes,index);
			index+=sizeof(float);
			sd.Position.z = BitConverter.ToSingle(skeletons.skeletonsBytes,index);
			index+=sizeof(float);
				
			sd.Position.w = 0;
				
			if(i1 <2)
			{
				for(int j = 0;j< 20;j++)
				{
					byte jointTrackingMode = skeletons.skeletonsBytes[index++];
					if(jointTrackingMode == 0){
						
						sd.eSkeletonPositionTrackingState[j] = Kinect.NuiSkeletonPositionTrackingState.NotTracked;
						}
					else{
							if(jointTrackingMode == 1){
								sd.eSkeletonPositionTrackingState[j] =  Kinect.NuiSkeletonPositionTrackingState.Inferred;
							}
							else{ 
								if(jointTrackingMode == 2){
									sd.eSkeletonPositionTrackingState[j] =  Kinect.NuiSkeletonPositionTrackingState.Tracked;
								}
							}
						}
						
					sd.SkeletonPositions[j].w = BitConverter.ToSingle(skeletons.skeletonsBytes,index);
					index+=sizeof(float);	
					sd.SkeletonPositions[j].x = BitConverter.ToSingle(skeletons.skeletonsBytes,index);
					index+=sizeof(float);					 
					sd.SkeletonPositions[j].z = -BitConverter.ToSingle(skeletons.skeletonsBytes,index);
					index+=sizeof(float);
					sd.SkeletonPositions[j].y = BitConverter.ToSingle(skeletons.skeletonsBytes,index);
					index+=sizeof(float);
					index=index +4*sizeof(float);
					
							
				}
					
			}
			else
				{
					for(int j = 0;j< 20;j++)
				{
					
					
					sd.eSkeletonPositionTrackingState[j] = Kinect.NuiSkeletonPositionTrackingState.NotTracked;
									
					sd.SkeletonPositions[j].w = 0;
					sd.SkeletonPositions[j].x = 0;
					sd.SkeletonPositions[j].y = 0;
					sd.SkeletonPositions[j].z = 0;
							
				}
				}
			
			sd.dwUserIndex = (uint)i1;	
			sd.dwQualityFlags = 0;				
			skeleton.SkeletonData[i1] = sd;
					
		}	
		
			
		}	
	}

	float KinectInterface.getSensorHeight ()
	{
		return 1;
	}

	Vector3 KinectInterface.getKinectCenter ()
	{
		return new Vector3(0,0,0);
	}

	Vector4 KinectInterface.getLookAt ()
	{
		return new Vector4(0,0,0,0);
	}

	bool KinectInterface.pollSkeleton ()
	{
				if (!updatedSkeleton)
		{
		newSkeleton = true;
			smoothParameters.fSmoothing = smoothing;
			smoothParameters.fCorrection = correction;
			smoothParameters.fJitterRadius = jitterRadius;
			smoothParameters.fMaxDeviationRadius = maxDeviationRadius;
			smoothParameters.fPrediction = prediction;
			int hr = NativeMethods.NuiTransformSmooth(ref skeleton,ref smoothParameters);
		}
		return this.newSkeleton;
	}

	NuiSkeletonFrame KinectInterface.getSkeleton ()
	{
	return this.skeleton;
	}

	bool KinectInterface.pollColor ()
	{
		return false;
	}

	Color32[] KinectInterface.getColor ()
	{
		return new Color32[0];
	}

	bool KinectInterface.pollDepth ()
	{
		return false;
	}

	short[] KinectInterface.getDepth ()
	{
		return new short[0];
	}

}
