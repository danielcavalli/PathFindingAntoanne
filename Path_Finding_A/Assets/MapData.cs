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
	public bool verified = false;

	void Start()
	{
		te = GameObject.Find ("GameManager");
		code = te.GetComponent<TileSettings> ();
		this.name = nindex.ToString() + index.ToString();
		Type = te.GetComponent<TileSettings> ().grid_type[index,nindex];
	}

	void Update()
	{
		if (selected)GetComponent<SpriteRenderer>().color = Color.yellow;
		if (verified)GetComponent<SpriteRenderer>().color = Color.green;
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
			case "Wall":
				GetComponent<SpriteRenderer>().color = Color.grey;
				Type = "Wall";
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
			case "Lagin":
				GetComponent<SpriteRenderer>().color = Color.cyan;
				Type = "Lagin";
				FindObjectOfType<Pathfinding>().dest = this.GetComponent<MapData>();
				break;
		}
	}
}
