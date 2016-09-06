using UnityEngine;
using System.Collections;

public class Pathfinding : MonoBehaviour
{
	public MapData dest;
	public MapData start;

	void PF(MapData actual)
	{
		if (actual.name != dest.name) {
			int MV = 100000;
			for (int i = -1; i < 2; i ++) {
				for (int n = -1; n < 2; n++) {
					if (i != 0 && n != 0) {
						if (i == 0 || n == 0) {
							if (TV (Find (actual, i, n), 10) < MV)
								MV = TV (Find (actual, i, n), 10);
						} else {
							if (TV (Find (actual, i, n), 14) < MV)
								MV = TV (Find (actual, i, n), 14);
						}
					}
				}
			}

			for (int i = -1; i < 2; i ++) {
				for (int n = -1; n < 2; n++) {
					if (i != 0 && n != 0) {
						if (i == 0 || n == 0) {
							if (TV (Find (actual, i, n), 10) == MV) {
								Find (actual, i, n).selected = true;
								PF (Find (actual, i, n));
							}
						} else {
							if (TV (Find (actual, i, n), 14) == MV) {
								Find (actual, i, n).selected = true;
								PF (Find (actual, i, n));
							}
						}
					}
				}
			}
		}
	}

	int TV (MapData Ot, int V)
	{
		return(V+ 10*(Mathf.Abs(dest.index - Ot.index) + Mathf(dest.nindex - Ot.nindex)));
	}

	MapData Find(MapData actual, int i, int n)
	{
		return GameObject.Find((actual.index + i).ToString()+(actual.nindex + n).ToString()).GetComponent<MapData>();
	}

}