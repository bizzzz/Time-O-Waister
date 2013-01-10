var target : Transform;
var damping = 6.0;
var smooth = true;
var direction = 0;
@script AddComponentMenu("Camera-Control/Smooth Look At")
var g ;

function LateUpdate () {

		//target =GameObject.Find("Cube5").transform;
		
		if(Input.GetKeyDown("1"))
		g =GameObject.Find("Cube1");
		if(Input.GetKeyDown("2"))
		g =GameObject.Find("Cube2");
		if(Input.GetKeyDown("3"))
		g =GameObject.Find("Cube3");
		if(Input.GetKeyDown("4"))
		g =GameObject.Find("Cube4");
		if(Input.GetKeyDown("5"))
		g =GameObject.Find("Cube5");
		if(Input.GetKeyDown("6"))
		g =GameObject.Find("Cube6");
		if(Input.GetKeyDown("7"))
		g =GameObject.Find("Cube7");
		if(Input.GetKeyDown("8"))
		g =GameObject.Find("Cube8");
		if(Input.GetKeyDown("9"))
		g =GameObject.Find("Cube9");
				
	//	target =g.transform;

		
	if (target) {
		if (smooth)
		{
			// Look at and dampen the rotation
			var rotation = Quaternion.LookRotation(target.position - transform.position);
			transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
		}
		else
		{
			// Just lookat
		    transform.LookAt(target);
		}
	}
}

function Start () {
			g =GameObject.Find("Cube1");
	// Make the rigid body not change rotation
   	if (rigidbody)
		rigidbody.freezeRotation = true;
}
function UpdateTarget ( t : Transform) {
		target = t;
}
