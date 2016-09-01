using UnityEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.IO;

public class TileSettings : MonoBehaviour
{
	//Lists
	List<string> lines = new List<string>();
	public List<string> linesCount = new List<string>();
	//Grid Variables
	public float[] grid_x;
	public float[] grid_y;
	public string[,] grid_type;
	public int columns;
	public int rows;
	int map = 0;
	//Other Variables
	public GameObject Tile;
	public GameObject Tile2;
	public int index;
	public int nindex;
	public int typo;
	public static bool canUseSave = false;
	
	// This creates the grid and set 'grid_type' to Null as default
	void grid()
	{
		grid_x = new float[rows];
		grid_y = new float[columns];
		grid_type = new string[rows,columns];
		for(int i = 0;i < rows;i++)
		{
			for (int n = 0;n < columns;n++)
			{
				grid_x[i] = i*6f;
				grid_y[n] = n*6f;
				grid_type[i,n] = "Null";
			}
		}
	}
	//Reads the Setting .mps file and writes the values to each type of "tile" to the grid_type variable
	//If the limit of the array was modified since the last run it will rewrite the .mps file
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
		if(linesCount.Count != (rows*columns))
		{
			using (StreamWriter file = new StreamWriter(filename))
			{
				for(var i = 0;i < rows;i++)
				{
					for (var n = 0;n < columns;n++)
					{
						file.WriteLine("|" + grid_type[i,n]);
					}
				}
				file.Close();
			}
			SetGridType("MapSettings.mps");
		}
	}
	void Start()
	{
		grid ();
		SetGridType("MapSettings.mps");
		Tile.GetComponent<MapData> ().index = 0;
		Tile.GetComponent<MapData> ().nindex = 0;
		for (int i = 0; i < rows; i++)
		{
			//Tile.GetComponent<MapData>().index = i;
			for (int n = 0; n < columns; n++)
			{
				grid_type[i,n] = linesCount[map].Split('|')[1];
				Tile.GetComponent<MapData>().nindex++;
				switch(grid_type[i,n])
				{
				case "Null":
					//ile.GetComponent<SpriteRenderer>().color = Color.white;
					//Tile.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/null");
					Instantiate(Tile, new Vector3((float)grid_x[i], 0, (float)grid_y[n]), Tile.transform.rotation);
					break;
				case "Street":
					//Tile.GetComponent<SpriteRenderer>().color = Color.white;
					//Tile.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Line");
					Instantiate(Tile, new Vector3((float)grid_x[i], 0, (float)grid_y[n]), Tile.transform.rotation);
					break;
				case "Bulding1":
					//Tile.GetComponent<SpriteRenderer>().color = Color.blue;
					//Tile.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/null");
					Instantiate(Tile, new Vector3((float)grid_x[i], 0, (float)grid_y[n]), Tile.transform.rotation);
					break;
				case "Bulding2":
					//Tile.GetComponent<SpriteRenderer>().color = Color.yellow;
					//Tile.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/null");
					Instantiate(Tile, new Vector3((float)grid_x[i], 0, (float)grid_y[n]), Tile.transform.rotation);
					break;
				}
				map++;
			}
		}
		canUseSave = true;
	}
}