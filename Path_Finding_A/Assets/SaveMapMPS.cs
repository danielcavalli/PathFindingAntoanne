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
	bool runned = false;
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
			}
		}
	}
	public void runcode(int r, int c)
	{
		coluna = c;
		linha = r;
		runned = true;
	}
	void Update () 
	{
		if(TileSettings.canUseSave == true && runned)
		{
				grid();
				TileSettings.canUseSave = false;
		}
		if(Input.GetKeyDown (KeyCode.F12) && canSave < 0  && runned)
		{
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
		canSave--;
	}
}
