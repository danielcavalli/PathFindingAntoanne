using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MapSettings : MonoBehaviour {

	bool TileSet;
	bool rwasdefined;
	GameObject te;
	int r;
	int c;

	void Start ()
	{

		var input = gameObject.GetComponent<InputField>();
		var se= new InputField.SubmitEvent();
		se.AddListener(SubmitName);
		input.onEndEdit = se;
		te = GameObject.Find ("GameManager");
		rwasdefined = false;
		TileSet = false;
	}
	
	private void SubmitName(string arg0)
	{
		if(rwasdefined && !TileSet) 
		{
			c= int.Parse(arg0);
			Debug.Log("Number of Columns defined");
			Debug.Log("RUNNING PHASE 1");
			te.GetComponent<TileSettings> ().runcode(r,c);
			te.GetComponent<SaveMapMPS>().runcode(r,c);
			TileSet = true;
			GameObject.Find("InputField").SetActive(false);
		}
		else
		{
			Debug.Log("Number of Rows defined");
			r=int.Parse(arg0);
			rwasdefined = true;
		}
	}

	void Update () 
	{
	}
}
