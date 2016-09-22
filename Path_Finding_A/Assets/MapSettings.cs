using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MapSettings : MonoBehaviour {

	bool TileSet;
	bool rwasdefined;
	GameObject te;
	public static int rows;
	public static int columns;

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
			columns= int.Parse(arg0);
			TileSet = true;
			te.GetComponent<TileSettings>().runcode();
			GameObject.Find("InputField").SetActive(false);
		}
		else
		{
			rows=int.Parse(arg0);
			rwasdefined = true;
		}
	}
}
