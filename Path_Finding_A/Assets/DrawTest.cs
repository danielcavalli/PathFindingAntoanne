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
	public GameObject[,] Tile_Control;
	public string[,] tile_type;
	public MapData[,] Tile;
	public static int control;
	
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
	void Start()
	{
		control = 0;
	}
	public void runcode() 
	{
		linha= GetComponent<TileSettings>().linha;
		coluna=GetComponent<TileSettings>().coluna;
		Tile_Control = new GameObject[linha,coluna];
		Tile = new MapData[linha,coluna];
		tile_type = new string[linha,coluna];
		for (int i = 0; i < linha;i++)
		{
			for (int n = 0; n < coluna;n++)
			{
				Tile_Control[i,n] = GameObject.Find((i.ToString() +"|"+ n.ToString()));
				Tile[i,n] = Tile_Control[i,n].GetComponent<MapData>();
				tile_type[i,n] = Tile[i,n].Type;
			}
		}
		Debug.Log (tile_type [1, 2]);
		for (int i = 0; i < linha;i++)
		{
			for (int n = 0; n < coluna;n++)
			{
				if(i > 0)
				{
					if(tile_type[i-1,n].Equals("Wall") && tile_type[i,n].Equals("Wall"))
					{
						Tile[i,n].ChangeSprite("2");
						Tile_Control[i,n].transform.rotation = Quaternion.Euler (new Vector3(90f,0,0));
					}
				}
				if(i > 0 && i < linha-1)
				{
					if(tile_type[i+1,n].Equals("Wall") && tile_type[i,n].Equals("Wall"))
					{
						Tile[i,n].ChangeSprite("2");
						Tile_Control[i,n].transform.rotation = Quaternion.Euler (new Vector3(90f,180f,0));
					}
					if(tile_type[i-1,n].Equals("Wall") && tile_type[i,n].Equals("Wall") && tile_type[i+1,n].Equals("Wall"))
					{
						Tile[i,n].ChangeSprite("7");
						Tile_Control[i,n].transform.rotation = Quaternion.Euler (new Vector3(90f,0,0));
					}
				}
				if(i == 0)
				{
					if(tile_type[i+1,n].Equals("Wall") && tile_type[i,n].Equals("Wall"))
					{
						Tile[i,n].ChangeSprite("2");
						Tile_Control[i,n].transform.rotation = Quaternion.Euler (new Vector3(90f,180f,0));
					}
				}
				if(n < coluna-1 && n != 0)
				{
					if(tile_type[i,n+1].Equals("Wall") && tile_type[i,n].Equals("Wall"))
					{
						Tile[i,n].ChangeSprite("3");
						Tile_Control[i,n].transform.rotation = Quaternion.Euler (new Vector3(90f,180f,0));
					}
					if(tile_type[i,n-1].Equals("Wall") && tile_type[i,n].Equals("Wall"))
					{
						Tile[i,n].ChangeSprite("3");
						Tile_Control[i,n].transform.rotation = Quaternion.Euler (new Vector3(90f,0f,0));
					}
					if(tile_type[i,n+1].Equals("Wall") && tile_type[i,n].Equals("Wall") && tile_type[i,n-1].Equals("Wall"))
					{
						Tile[i,n].ChangeSprite("7");
						Tile_Control[i,n].transform.rotation = Quaternion.Euler (new Vector3(90f,90f,0));
					}
				}
				if(n == 0)
				{
					if(tile_type[i,n+1].Equals("Wall") && tile_type[i,n].Equals("Wall"))
					{
						Tile[i,n].ChangeSprite("7");
						Tile_Control[i,n].transform.rotation = Quaternion.Euler (new Vector3(90f,90f,0));
					}
				}
				if(n < coluna-1 && i < linha-1)
				{
					if(tile_type[i+1,n].Equals("Wall") && tile_type[i,n].Equals("Wall") && tile_type[i,n+1].Equals("Wall"))
					{
						Tile[i,n].ChangeSprite("4");
						Tile_Control[i,n].transform.rotation = Quaternion.Euler (new Vector3(90f,270f,0));
					}
				}
				if(n > 0 && i < linha-1)
				{
					if(tile_type[i+1,n].Equals("Wall") && tile_type[i,n].Equals("Wall") && tile_type[i,n-1].Equals("Wall"))
					{
						Tile[i,n].ChangeSprite("4");
						Tile_Control[i,n].transform.rotation = Quaternion.Euler (new Vector3(90f,0,0));
					}
				}
				if(n < coluna-1 && i > 0)
				{
					if(tile_type[i-1,n].Equals("Wall") && tile_type[i,n].Equals("Wall") && tile_type[i,n+1].Equals("Wall"))
					{
						Tile[i,n].ChangeSprite("4");
						Tile_Control[i,n].transform.rotation = Quaternion.Euler (new Vector3(90f,180f,0));
					}
				}
				if(n < 0 && i < linha-1)
				{
					if(tile_type[i+1,n].Equals("Wall") && tile_type[i,n].Equals("Wall") && tile_type[i,n+1].Equals("Wall"))
					{
						Tile[i,n].ChangeSprite("4");
						Tile_Control[i,n].transform.rotation = Quaternion.Euler (new Vector3(90f,270f,0));
					}
				}
				if(n > 0 && i > 0)
				{
					if(tile_type[i-1,n].Equals("Wall") && tile_type[i,n].Equals("Wall") && tile_type[i,n-1].Equals("Wall"))
					{
						Tile[i,n].ChangeSprite("4");
						Tile_Control[i,n].transform.rotation = Quaternion.Euler (new Vector3(90f,90f,0));
					}
				}
				if(i>0 && i < linha-1 && n > 0)
				{
					if(tile_type[i+1,n].Equals("Wall") && tile_type[i,n].Equals("Wall") && tile_type[i,n-1].Equals("Wall") && tile_type[i-1,n].Equals("Wall"))
					{
						Tile[i,n].ChangeSprite("5");
						Tile_Control[i,n].transform.rotation = Quaternion.Euler (new Vector3(90f,0,0));
					}
				}
				if(i>0 && i < linha-1 && n < coluna-1)
				{
					if(tile_type[i+1,n].Equals("Wall") && tile_type[i,n].Equals("Wall") && tile_type[i,n+1].Equals("Wall") && tile_type[i-1,n].Equals("Wall"))
					{
						Tile[i,n].ChangeSprite("5");
						Tile_Control[i,n].transform.rotation = Quaternion.Euler (new Vector3(90f,0f,0));
					}
				}
				if(n>0 && i < linha-1 && n < coluna-1)
				{
					if(tile_type[i+1,n].Equals("Wall") && tile_type[i,n].Equals("Wall") && tile_type[i,n+1].Equals("Wall") && tile_type[i,n-1].Equals("Wall"))
					{
						Tile[i,n].ChangeSprite("5");
						Tile_Control[i,n].transform.rotation = Quaternion.Euler (new Vector3(90f,270f,0));
					}
				}
				if(n>0 && i > 0 && n < coluna-1)
				{
					if(tile_type[i-1,n].Equals("Wall") && tile_type[i,n].Equals("Wall") && tile_type[i,n+1].Equals("Wall") && tile_type[i,n-1].Equals("Wall"))
					{
						Tile[i,n].ChangeSprite("5");
						Tile_Control[i,n].transform.rotation = Quaternion.Euler (new Vector3(90f,90f,0));
					}
				}
			}
		}
	}
}