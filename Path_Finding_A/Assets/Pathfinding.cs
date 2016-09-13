using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Pathfinding : MonoBehaviour
{
	public MapData dest;
	public MapData start;
	

	public void PathFinding(MapData actual)
	{
		List<MapData> minMapdList = new List<MapData>();
		if (actual.name != dest.name) 
		{
			MapData temp;
			minMapdList.Add(actual);
			int minVal = 100000;

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

			foreach(MapData m in minMapdList)
			{
				if(!(m.selected) && !(m.Type.Equals("Finish")))
				{
					m.selected = true;
					PathFinding(m);
				}
			}

			/*Da pra excluir
			 * for (int i = -1; i < 2; i ++)Da pra excluir
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
									}*/
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

	public int TotalValue (MapData Ot/*Tile de origem*/, MapData Tdest, int V)
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