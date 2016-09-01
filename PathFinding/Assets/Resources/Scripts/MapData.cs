using UnityEngine;
using System.Collections;

public class MapData : MonoBehaviour
{
	GameObject te;
	Component code;
	public string Type;
	public int index;
	public int nindex;
	int population;
	public Sprite line;
	void Start()
	{
		te = GameObject.Find ("GameManager");
		code = te.GetComponent<TileSettings> ();
		this.name = nindex.ToString();
		Type = te.GetComponent<TileSettings> ().grid_type[index,nindex];
		line = Resources.Load<Sprite>("Line");
		switch(Type)
		{
			case "Null":
				//GetComponent<MeshRenderer>().color = Color.white;
				Type = "Null";
				break;
			case "Street":
				//GetComponent<MeshRenderer>().color = Color.white;
				//GetComponent<MeshRenderer>().renderer = Resources.Load<Material>("Art/Chao");
				Type = "Street";
				break;
		}
	}
	void OnMouseDown()
	{
	}
}