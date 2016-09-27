﻿using UnityEngine;
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
	public int coluna;
	public int linha;
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
				grid_type[n,i] = ta.GetComponent<MapData>().Type;
				Debug.Log (grid_type[n,i]);
			}
		}
	}
	void Start()
	{
		linha = MapSettings.rows;
		coluna = MapSettings.columns;
	}
	public void saveit()
	{
		Debug.Log ("SaveMapF12: " + linha + " || " + coluna);
		grid();
		canSave = 150;
		using (StreamWriter file = new StreamWriter("MapSettings.mps"))
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
	void Update () 
	{
		if(TileSettings.canUseSave == true)
		{
			linha = MapSettings.rows;
			coluna = MapSettings.columns;
			Debug.Log ("SaveMap: " + linha + " || " + coluna);
			grid();
			TileSettings.canUseSave = false;
		}
		if(Input.GetKeyDown (KeyCode.F12) && canSave < 0)
		{
			saveit ();
		}
		canSave--;
	}
}