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
	GameObject[] t;
	public static int l;
	public static int c;
	
	// This creates the grid and set 'grid_type' to Null as default
	void grid()
	{
		grid_x = new float[linha];
		grid_y = new float[coluna];
		grid_type = new string[linha,coluna];
		for(int i = 0;i < linha;i++)
		{
			for (int n = 0;n < coluna;n++)
			{
				grid_x[i] = i*1.2f;
				grid_y[n] = n*1.2f;
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
	}
	public void runcode()
	{
		t = new GameObject[9];
		linha = 10;
		coluna = 10;
		if (linha == 10 && !yes) 
		{
			linha = MapSettings.rows;
			coluna = MapSettings.columns;
			this.GetComponent<RedoneSettings>().runcode ();
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
			linha = int.Parse(linesCount2[0].Split('|')[1]);
			coluna = int.Parse(linesCount2[1].Split('|')[1]);
		}
		l = linha;
		c = coluna;
		grid();
		SetGridType("MapSettings.mps");
		Tile.GetComponent<MapData> ().index = 0;
		Tile.GetComponent<MapData> ().nindex = 0;
		for (int i = 0; i < linha; i++)
		{
			Tile.GetComponent<MapData>().index = i;
			for (int n = 0; n < coluna; n++)
			{
				grid_type[i,n] = linesCount[map].Split('|')[1];
				map++;
				Tile.GetComponent<MapData>().nindex = n;
				switch(grid_type[i,n])
				{
					case "Null":
						Tile.GetComponent<SpriteRenderer>().color = Color.white;
					Tile.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/null 1");
						Instantiate(Tile, new Vector3((float)grid_x[i], 0, (float)grid_y[n]), Tile.transform.rotation);
						break;
					case "Wall":
					Tile.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/1");
						Tile.GetComponent<SpriteRenderer>().color = Color.white;
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
		//GetComponent<DrawTest> ().runcode ();
	}
}



























