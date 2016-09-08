using UnityEngine;
using System.Collections;

public class Pathfinding : MonoBehaviour
{
	public MapData dest;
	public MapData start;
	

	public void PathFinding(MapData actual)
	{
		if (actual.name != dest.name) 
		{
			int MV = 100000;
			MapData temp;
			for (int i = -1; i < 2; i ++) 
			{
				for (int n = -1; n < 2; n++) 
				{
					if (i != 0 || n != 0) 
					{
						temp = Find (actual, i, n);
						if(!temp.selected)
						{
							if (i == 0 || n == 0) 
							{
								if (TotalValue (temp, dest, 10) < MV)
									MV = TotalValue (temp, dest, 10);
							} 
							else 
							{
								if (TotalValue (temp, dest, 14) < MV)
									MV = TotalValue (temp, dest, 14);
							}
						}
					}
				}
			}

			for (int i = -1; i < 2; i ++)/*Da pra excluir*/
			{
				for (int n = -1; n < 2; n++) 
				{
					temp = Find (actual, i, n);
					if (i != 0 || n != 0) 
					{	
						if(!temp.selected)
						{
							if(!temp.Type.Equals("Finish"))
							{
								if (i == 0 || n == 0) 
								{
									if (TotalValue (temp, dest, 10) == MV)
									{
										temp.selected = true;
										PathFinding (temp);
									}
								} 
								else 
								{
									if (TotalValue (temp, dest, 14) == MV)
									{
										temp.selected = true;
										PathFinding (temp);
									}
								}
							}
						}
					}
				}
			}
		}

		//ReturnPathFinding (dest);

	}

	public void ReturnPathFinding(MapData actual)
	{
		if (actual.name != start.name) 
		{
			int MV = 100000;
			for (int i = -1; i < 2; i ++) 
			{
				for (int n = -1; n < 2; n++) 
				{
					if (i != 0 || n != 0) 
					{
						if(Find (actual,i,n).selected)
						{
						if (i == 0 || n == 0) 
						{
							if (TotalValue (Find (actual, i, n), start, 10) < MV)
								MV = TotalValue (Find (actual, i, n), start, 10);
							}
						else 
						{
							if (TotalValue (Find (actual, i, n), start, 14) < MV)
								MV = TotalValue (Find (actual, i, n), start, 14);
						}
						}
					}
				}
			}
			
			for (int i = -1; i < 2; i ++) 
			{
				for (int n = -1; n < 2; n++) 
				{
					if (i != 0 || n != 0)
					{
						if(!Find(actual,i,n).Type.Equals("Start"))
						{
							if(Find (actual,i,n).selected)
							{
								if (i == 0 || n == 0) 
								{
									if (TotalValue (Find (actual, i, n), start, 10) == MV) 
									{
										Find (actual, i, n).verified = true;
										Find (actual, i, n).selected = false;
										ReturnPathFinding (Find (actual, i, n));
									}
								} 
								else 
								{
									if (TotalValue (Find (actual, i, n), start, 14) == MV) 
									{
										Find (actual, i, n).verified = true;
										Find (actual, i, n).selected = false;
										ReturnPathFinding (Find (actual, i, n));
									}
								}
							}
						}
					}
				}
			}
		}
	}

	public int TotalValue (MapData Ot/*Tile de origem*/, MapData Tdest, int V)//eu n sei fazer conta
	{
		if (Ot.Type.Equals ("Wall") || Ot == null) {
			return 50000;
		}

		return(V + 10*(Mathf.Abs(Tdest.index - Ot.index) + Mathf.Abs(Tdest.nindex - Ot.nindex)));
	}

	public MapData Find(MapData actual, int i, int n)
	{
		if (actual.index + i < 0 || actual.nindex + n < 0)
			return null;
		else
		return GameObject.Find((actual.index + i).ToString()+(actual.nindex + n).ToString()).GetComponent<MapData>();
	}

}