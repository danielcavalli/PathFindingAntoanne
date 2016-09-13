using UnityEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.IO;

public class RedoneSettings : MonoBehaviour
{
	//Lists
	//Grid Variables
	float[] grid_x;
	float[] grid_y;
	public string[,] grid_type;
	public int coluna;
	public int linha;
	
	void grid()
	{
		grid_type = new string[linha,coluna];
		for(int i = 0;i < linha;i++)
		{
			for (int n = 0;n < coluna;n++)
			{
				grid_type[i,n] = "Null";
			}
		}
	}
	void SetGridType(string filename)
	{
		using (StreamWriter file = new StreamWriter(filename))
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
	void Start()
	{
		grid ();
		SetGridType("MapSettings.mps");
	}
}