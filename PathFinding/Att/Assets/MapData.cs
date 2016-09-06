using UnityEngine;
using System.Collections;

public class MapData : MonoBehaviour
{
	GameObject te;
	Component code;
	public string Type;
	public int index;
	public int nindex;
	public bool selected = false;

	void Start()
	{
		te = GameObject.Find ("GameManager");
		code = te.GetComponent<TileSettings> ();
		this.name = index.ToString() + nindex.ToString();
		Type = te.GetComponent<TileSettings> ().grid_type[index,nindex];
	}
	void OnMouseDown()
	{
		Type = MoveCamera.type;
		switch(MoveCamera.type)
		{
			case "Null":
				GetComponent<SpriteRenderer>().color = Color.white;
				Type = "Null";
				break;
			case "Street":
				GetComponent<SpriteRenderer>().color = Color.grey;
				Type = "Street";
				break;
			case "Start":
				GetComponent<SpriteRenderer>().color = Color.blue;
				Type = "Start";
			FindObjectOfType<Pathfinding>().start = this.GetComponent<MapData>();
				break;
			case "Finish":
				GetComponent<SpriteRenderer>().color = Color.red;
				Type = "Finish";
			FindObjectOfType<Pathfinding>().dest = this.GetComponent<MapData>();
				break;


		}
	}
}
