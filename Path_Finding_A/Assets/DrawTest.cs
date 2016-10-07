using UnityEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.IO;

public class DrawTest : MonoBehaviour 
{

	List<string> lines = new List<string>();
	public List<string> linesCount = new List<string>();
	public List<string> linesCount2 = new List<string>();
	//Grid Variables
	float[] grid_x;
	float[] grid_y;
	public string[,] grid_type;
	public int coluna;
	public int linha;
	int map = 0;
	//Other Variables
	public GameObject Tile;
	public GameObject Tile2;
	public int index;
	public int nindex;
	public int typo;
	public static bool canUseSave = false;
	public bool yes = false;
	
	void grid()
	{
		grid_x = new float[linha];
		grid_y = new float[coluna];
		grid_type = new string[linha,coluna];
		for(int i = 0;i < linha;i++)
		{
			for (int n = 0;n < coluna;n++)
			{
				grid_x[i]=i*1.2f;
				grid_y[n]=n*1.2f;
				grid_type[i,n]="Null";
			}
		}
	}
	void SetGridType(string filename)
	{
		using (StreamReader file = new StreamReader(filename))
		{
			string line;
			while ((line = file.ReadLine()) != null)
			{
				linesCount.Add(line);
			}
		}
	}
	
	public void runcode() 
	{
		linha=10;
		coluna=10;
		if (linha==10 && !yes) 
		{
			linha=MapSettings.rows;
			coluna=MapSettings.columns;
		}
		else
		{
			using (StreamReader file = new StreamReader("MapS.mps"))
			{
				string line;
				while ((line = file.ReadLine()) != null)
				{
					linesCount2.Add(line);
				}
			}
			linha=int.Parse(linesCount2[0].Split('|')[1]);
			coluna=int.Parse(linesCount2[1].Split('|')[1]);
		}
		grid();
		SetGridType("MapSettings.mps");
		Tile.GetComponent<MapData>().index=0;
		Tile.GetComponent<MapData>().nindex=0;
		for (int i=0;i<linha;i++) 
		{
			for(int n=0;n<coluna;n++) 
			{
				grid_type[i,n]=linesCount[map].Split('|')[1];
				map++;
			}
		}

	}
}
