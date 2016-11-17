using UnityEngine;
using System.Collections;

public class Walk : MonoBehaviour {

	GameObject temp;
	float t = 0;
	bool go;
	bool keep;
	MapData start;
	void Start()
	{
		start = GameObject.FindGameObjectWithTag ("Start").GetComponent<MapData>();
		go = false;
		keep = true;
		Walking (start);
	}
	
	public void Walking(MapData actual)
	{
		for (int i = -1; i < 2; i ++) 
		{
			for (int n = -1; n < 2; n++) 
			{
				if (i != 0 || n != 0) 
				{
					temp = Find (actual, i, n);
					if(temp != null)
					{
						if(temp.gameObject.GetComponent<MapData>().verified || temp.gameObject.GetComponent<MapData>().Type == "Finish")
						{
							temp.gameObject.GetComponent<MapData>().verified = false;
							go = true;
							i = 5;
							n = 5;							
							t = 0;
							if(temp.gameObject.GetComponent<MapData>().Type == "Finish")
							{
								keep = false;
							}
						}
					}
				}
			}
		}
	}

	void Update()
	{
		if (go) 
		{
			this.transform.position = new Vector3 (Mathf.Lerp (this.transform.position.x, temp.transform.position.x, t),
			                                       1,
			                                       Mathf.Lerp (this.transform.position.z, temp.transform.position.z, t));
			t += 0.5f * Time.deltaTime;
			Debug.Log(t);
		}
		if (t >= 1)
		{
			this.transform.position = new Vector3(temp.transform.position.x,1, temp.transform.position.z);
			go = false;
			if(keep)
				Walking(temp.GetComponent<MapData>());
		}
	}

	public GameObject Find(MapData actual, int i, int n)
	{
		GameObject settings = GameObject.Find("GameManager");
		if (actual.index + i < 0 || actual.nindex + n < 0 || actual.index + i >= settings.GetComponent<TileSettings>().linha || actual.nindex + n >= settings.GetComponent<TileSettings>().coluna)
			return null;
		else
			return GameObject.Find((actual.index + i).ToString() +"|"+ (actual.nindex + n).ToString());
	}
}