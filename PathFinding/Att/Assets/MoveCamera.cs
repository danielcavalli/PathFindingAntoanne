using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {


	public int speed = 1;
	public static string type;
	void Start () 
	{
	
	}
	

	void Update () 
	{
		if (Input.GetKey (KeyCode.D)) 
		{
			transform.position += new Vector3(speed,0,0);
		}
		if (Input.GetKey (KeyCode.A)) 
		{
			transform.position += new Vector3(-speed,0,0);
		}
		if (Input.GetKey (KeyCode.W)) 
		{
			transform.position += new Vector3(0,0,speed);
		}
		if (Input.GetKey (KeyCode.S)) 
		{
			transform.position += new Vector3(0,0,-speed);
		}
		if (Input.GetKey (KeyCode.S)) 
		{
			transform.position += new Vector3(0,0,-speed);
		}
		if (Input.GetKeyDown(KeyCode.Q)) 
		{
			type = "Null";
		}
		if (Input.GetKeyDown(KeyCode.E)) 
		{
			type = "Street";
		}
		if (Input.GetKeyDown(KeyCode.R)) 
		{
			type = "Start";
		}
		if (Input.GetKeyDown(KeyCode.T)) 
		{
			type = "Finish";
		}
	}
}
