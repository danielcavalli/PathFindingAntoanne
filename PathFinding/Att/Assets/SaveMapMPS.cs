using UnityEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.IO;

public class SaveMapMPS : MonoBehaviour {
	
	string[,] grid_type; 
	public int coluna = 100;
	public int linha = 100;
	public GameObject ta;
	string name;
	int canSave;
	void grid()
	{
		grid_type = new string[linha,coluna];
		for(int i = 0;i < linha;i++)
		{
			for (int n = 0;n < coluna;n++)
			{
				name = i.ToString() + n.ToString();
				ta = GameObject.Find(name);
				grid_type[i,n] = ta.GetComponent<MapData>().Type;
				Debug.Log (grid_type[i,n]);
			}
		}
	}
	void Update () 
	{
		if(TileSettings.canUseSave == true)
		{
				grid();
				TileSettings.canUseSave = false;
		}
		if(Input.GetKeyDown (KeyCode.F1) && canSave < 0)
		{
			grid();
			canSave = 150;
			using (StreamWriter file = new StreamWriter("MapSettings2.mps"))
			{
				for(var i = 0;i < linha;i++)
				{
					for (var n = 0;n < coluna;n++)
					{
						file.WriteLine("|" + grid_type[i,n]);
					}
				}
				file.Close();
			}
		}
		canSave--;
	}
}
