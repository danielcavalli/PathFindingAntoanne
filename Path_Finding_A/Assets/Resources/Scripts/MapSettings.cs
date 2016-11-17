using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.IO;

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
		if (rwasdefined && !TileSet) {
			columns = int.Parse (arg0);
			TileSet = true;
			te.GetComponent<TileSettings>().runcode();
			using (StreamWriter file = new StreamWriter("MapS.mps"))
			{
				file.WriteLine("|" + rows);
				file.WriteLine("|" + columns);
				file.Close();
			}
			GameObject.Find ("InputField").SetActive (false);
		} 
		else 
		{
			rows = int.Parse (arg0);
			rwasdefined = true;
		}
	}
}
