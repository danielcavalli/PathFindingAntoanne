using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {


	public int speed = 1;
	public static string type;
	bool run;
	void Start () 
	{
		run = false;
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
		if (Input.GetKeyDown (KeyCode.P)) {
			FindObjectOfType<Pathfinding>().Go();
		}
		if (Input.GetKeyDown(KeyCode.F1))
		{
			type = "Null";
		}
		if (Input.GetKeyDown(KeyCode.F3))
		{
			type = "Wall";
		}
		if (Input.GetKeyDown(KeyCode.F5))
		{
			type = "Start";
		}
		if (Input.GetKeyDown(KeyCode.F6))
		{
			type = "Finish";
		}
		if (Input.GetAxis ("Mouse ScrollWheel") > 0 && transform.position.y >= 25) 
		{
			transform.position += new Vector3(0,-speed,0);
		}
		if (Input.GetAxis ("Mouse ScrollWheel") < 0 && transform.position.y <= 125) 
		{
			transform.position += new Vector3(0,speed,0);
		}
		if (!run) 
		{
			if (DrawTest.control >= (TileSettings.l * TileSettings.c))
			{
				GameObject.Find ("GameManager").GetComponent<DrawTest> ().runcode ();
				Debug.Log (DrawTest.control);
				run = true;
			}
		}
	}
}
