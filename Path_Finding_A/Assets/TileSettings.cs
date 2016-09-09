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
	float[] grid_x;
	float[] grid_y;
	public string[,] grid_type;
	int map = 0;
	//Other Variables
	public GameObject Tile;
	public GameObject Tile2;
	public int index;
	public int nindex;
	public int typo;
	public static bool canUseSave = false;
	
	// This creates the grid and set 'grid_type' to Null as default
	void grid(int c, int r)
	{
		Debug.Log("RUNNING PHASE 3");
		grid_x = new float[r];
		grid_y = new float[c];
		grid_type = new string[r,c];
		for(int i = 0;i < r;i++)
		{
			for(int n = 0;n < c;n++)
			{
				grid_x[i] = i*1.2f;
				grid_y[n] = n*1.2f;
				grid_type[i,n] = "Null";
				/*grid_type[i][n] = gameObject.GetComponent("TileSetting").data[1];
           		if(grid_type[i][n] == "True")
            		Instantiate(T, new Vector3(grid_x[i], 0, grid_y[n]), Quaternion.identity);*/
			}
		}
	}
	//Reads the Setting .mps file and writes the values to each type of "tile" to the grid_type variable
	//If the limit of the array was modified since the last run it will rewrite the .mps file
	void SetGridType(string filename, int c, int r)
	{
		Debug.Log("RUNNING PHASE 3");
		using (StreamReader file = new StreamReader(filename))
		{
			string line;
			while ((line = file.ReadLine()) != null)
			{
				linesCount.Add(line);
			}
		}
		if(linesCount.Count != (r*c))
		{
			using (StreamWriter file = new StreamWriter(filename))
			{
				for(var i = 0;i < r;i++)
				{
					for (var n = 0;n < c;n++)
					{
						file.WriteLine("|" + grid_type[i,n]);
					}
				}
				file.Close();
			}
			SetGridType("MapSettings.mps",c,r);
		}
	}
	public void runcode(int c, int r)
	{
		/*Generate the Grid*/
		Debug.Log("RUNNING PHASE 2");
		grid (c,r);
		/*Load the Grid Configuration*/
		SetGridType("MapSettings.mps",c,r);
		Debug.Log("RUNNING PHASE 5");
		Tile.GetComponent<MapData>().index = 0;
		Tile.GetComponent<MapData>().nindex = 0;
		for (int i = 0; i < r; i++)
		{
			Tile.GetComponent<MapData>().index = i;
			for (int n = 0; n < c; n++)
			{
				grid_type[i,n] = linesCount[map].Split('|')[1];
				map++;
				Tile.GetComponent<MapData>().nindex = n;
				/*Set the Tile Type after read the Configuration File*/
				switch(grid_type[i,n])
				{
					case "Null":
						Tile.GetComponent<SpriteRenderer>().color = Color.white;
						Instantiate(Tile, new Vector3((float)grid_x[i], 0, (float)grid_y[n]), Tile.transform.rotation);
						break;
					case "Wall":
						Tile.GetComponent<SpriteRenderer>().color = Color.grey;
						Instantiate(Tile, new Vector3((float)grid_x[i], 0, (float)grid_y[n]), Tile.transform.rotation);
						break;
					case "Lagin":
						Tile.GetComponent<SpriteRenderer>().color = Color.cyan;
						Instantiate(Tile, new Vector3((float)grid_x[i], 0, (float)grid_y[n]), Tile.transform.rotation);
						break;
					case "Start":
						Tile.GetComponent<SpriteRenderer>().color = Color.blue;
						Instantiate(Tile, new Vector3((float)grid_x[i], 0, (float)grid_y[n]), Tile.transform.rotation);
						break;
					case "Finish":
						Tile.GetComponent<SpriteRenderer>().color = Color.red;
						Instantiate(Tile, new Vector3((float)grid_x[i], 0, (float)grid_y[n]), Tile.transform.rotation);
						break;
				}
			}
		}
		canUseSave = true;
	}
}