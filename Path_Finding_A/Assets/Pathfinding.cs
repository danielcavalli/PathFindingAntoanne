using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// PathFinding A* 
public class Pathfinding : MonoBehaviour
{
	MapData dest;
	MapData start;
	bool ret = false;

	public void Go()
	{
		start = GameObject.FindGameObjectWithTag ("Start").GetComponent<MapData>();
		dest = GameObject.FindGameObjectWithTag("Finish").GetComponent<MapData>();
		PathFinding (start);
	}

	void Update()
	{
		if(ret)
		{
			ret = false;
			ReturnPathFinding(dest);
		}
	}

	void PathFinding(MapData actual)
	{
		actual.falseWall = true;
		Debug.Log (actual.name); 
		List<MapData> minMapdList = new List<MapData>();
		MapData temp;
		int minVal = 100000;
		List<MapData> tPassedTiles = new List<MapData>();
		ret = false;			

		for (int i = -1; i < 2; i ++) 
		{
			for (int n = -1; n < 2; n++) 
			{
				if (i != 0 || n != 0) 
				{
					temp = Find (actual, i, n);
					if(temp != null)
					{
						if(!temp.selected && !temp.falseWall && !temp.Type.Equals("Wall"))
						{
							if (i == 0 || n == 0) 
							{
								if (TotalValue (temp, dest, 10) <= minVal)
								{
									if(TotalValue (temp, dest, 10) < minVal)
									{
										minMapdList.Clear();
										minVal = TotalValue (temp, dest, 10);
									}
	
									minMapdList.Add(temp);
								}
							} 
							else if (TotalValue (temp, dest, 14) <= minVal)
							{
								if(TotalValue (temp, dest, 14) < minVal)
								{
									minMapdList.Clear();
									minVal = TotalValue (temp, dest, 14);
								}									
									minMapdList.Add(temp);
							}
	
						}
					}
				}
			}
		}

		foreach(MapData m in minMapdList)
		{
			if(!m.selected &&!(m.Type.Equals("Finish")))
			{
				m.selected = true;
				tPassedTiles.Add(actual);
				PathFinding(m,tPassedTiles);
			}

			else
			{
				ret = true;
			}
		}

	}

	public void PathFinding(MapData actual, List<MapData> passedTiles)
	{
		Debug.Log (actual.name); 
		List<MapData> minMapdList = new List<MapData>();
		MapData temp;
		List<MapData> tPassedTiles = passedTiles;
		ret = false;
		
		int minVal = 100000;
		
		for (int i = -1; i < 2; i ++) 
		{
			for (int n = -1; n < 2; n++) 
			{
				if (i != 0 || n != 0) 
				{
					temp = Find (actual, i, n);
					if(temp != null)
					{
						if(!temp.selected && !temp.falseWall && !temp.Type.Equals("Wall"))
						{
							if (i == 0 || n == 0) 
							{
								if (TotalValue (temp, dest, 10) <= minVal)
								{
									if(TotalValue (temp, dest, 10) < minVal)
									{
										minMapdList.Clear();
										minVal = TotalValue (temp, dest, 10);
									}
									
									minMapdList.Add(temp);
								}
							} 
							else if (TotalValue (temp, dest, 14) <= minVal)
							{
								if(TotalValue (temp, dest, 14) < minVal)
								{
									minMapdList.Clear();
									minVal = TotalValue (temp, dest, 14);
								}
								
								minMapdList.Add(temp);
							}
							
						}
					}
				}
			}
		}
		
		if(minMapdList.Count <= 0)
		{
			actual.falseWall = true;
			MapData m = tPassedTiles[tPassedTiles.Count-1];
			tPassedTiles.RemoveAt(tPassedTiles.Count-1);
			PathFinding(m,tPassedTiles);
		}

		else
		{
			foreach(MapData m in minMapdList)
			{
				if(!m.selected &&!(m.Type.Equals("Finish")))
				{
					m.selected = true;
					tPassedTiles.Add(actual);
					PathFinding(m,tPassedTiles);
				}
				else
				{
					ret = true;
				}
			}
		}		
	}

		

	public void ReturnPathFinding(MapData actual)
	{
		MapData temp;
		List<MapData> minMapdList = new List<MapData>();
		if (actual.name != start.name) 
		{
			int MV = 100000;
			for (int i = -1; i < 2; i ++) 
			{
				for (int n = -1; n < 2; n++) 
				{
					if (i != 0 || n != 0) 
					{
						temp = Find (actual,i,n);
						if(temp != null)
						{
							if(temp.selected)
							{
								if (i == 0 || n == 0) 
								{
									if (TotalValue (temp, start, 10) <= MV)
									{
										if(TotalValue (temp, start, 10) < MV)
										{
											MV = TotalValue (temp, start, 10);
											minMapdList.Clear();
										}
										minMapdList.Add(temp);
									}
								}
								else 
								{
									if (TotalValue (temp, start, 14) <= MV)
									{
										if(TotalValue (temp, start, 14) < MV)
										{
											MV = TotalValue (temp, start, 14);
											minMapdList.Clear();
										}
										minMapdList.Add(temp);
									}
								}
							}
						}
					}
				}
			}

			foreach(MapData m in minMapdList)
			{
				if(!m.Type.Equals("Start"))
				{
					m.verified = true;
					m.selected = false;
					ReturnPathFinding(m);
				}
			}
		}
	}

	public int TotalValue (MapData Ot/*Tile de origem*/, MapData Tdest, int V)
	{

		return(V + 10*(Mathf.Abs(Tdest.index - Ot.index) + Mathf.Abs(Tdest.nindex - Ot.nindex)));
	}

	public MapData Find(MapData actual, int i, int n)
	{
		GameObject settings = GameObject.Find("GameManager");
		if (actual.index + i < 0 || actual.nindex + n < 0 || actual.index + i >= settings.GetComponent<TileSettings>().linha || actual.nindex + n >= settings.GetComponent<TileSettings>().coluna)
			return null;
		else
			return GameObject.Find((actual.index + n).ToString() +"|"+ (actual.nindex + i).ToString()).GetComponent<MapData>();
	}

}