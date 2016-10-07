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
	public bool falseWall = false;
	Sprite[] walls;

	void Start()
	{
		te = GameObject.Find ("GameManager");
		code = te.GetComponent<TileSettings> ();
		this.name = index.ToString() +"|"+ nindex.ToString();
		Type = te.GetComponent<TileSettings> ().grid_type[index,nindex];
		walls = new Sprite[6];
	}

	void Update()
	{
		if (selected)GetComponent<SpriteRenderer>().color = Color.yellow;
		if (verified)GetComponent<SpriteRenderer>().color = Color.green;
		if(!Type.Equals("Null"))this.tag = Type;
		else this.tag = "Ground";
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
				GetComponent<SpriteRenderer>().color = Color.white;
				GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("1");
				Type = "Wall";
				this.tag = "Wall";
				break;
			case "Start":
				GetComponent<SpriteRenderer>().color = Color.blue;
				Type = "Start";
				this.tag = "Start";
				break;
			case "Finish":
				GetComponent<SpriteRenderer>().color = Color.red;
				Type = "Finish";
				this.tag = "Finish";
				break;
			case "Lagin":
				GetComponent<SpriteRenderer>().color = Color.cyan;
				Type = "Lagin";
				this.tag = "Lagin";
				break;
		}
	}
}
