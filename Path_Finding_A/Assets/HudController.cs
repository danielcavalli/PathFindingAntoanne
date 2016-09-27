using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HudController : MonoBehaviour {


	GameObject[] HudObjs;

	void Start()
	{
		HudObjs = new GameObject[5];
		HudObjs [0] = GameObject.Find ("InputField");
		HudObjs [0].SetActive (false);
		HudObjs [1] = GameObject.Find ("b1");
		HudObjs [2] = GameObject.Find ("b2");
		HudObjs [3] = GameObject.Find ("PanelYes");
		HudObjs [3].SetActive (false);
		HudObjs [4] = GameObject.Find ("PanelYes2");
		HudObjs [4].SetActive (false);

	}


	public void new1()
	{
		HudObjs [1].SetActive(false);
		HudObjs [2].SetActive(false);
		HudObjs [3].SetActive(true);
	}
	public void new2()
	{
		HudObjs [3].SetActive(false);
		HudObjs [0].SetActive(true);
	}
	public void close()
	{
		HudObjs [1].SetActive(true);
		HudObjs [2].SetActive(true);
		HudObjs [3].SetActive(false);
		HudObjs [4].SetActive(false);
	}
	public void load1()
	{
		HudObjs [1].SetActive(false);
		HudObjs [2].SetActive(false);
		HudObjs [4].SetActive(true);
	}
	public void sure()
	{
		HudObjs [0].SetActive(true);
		HudObjs [3].SetActive(false);
		HudObjs [4].SetActive(false);
	}
}
