using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour
{

	private static int healthStat = 0;
	private static int hungerStat = 0;
	private static int thirstStat = 0;
	
	
	public static void UpdateStats(int healthStat, int hungerStat, int thirstStat)
	{
		StatsManager.healthStat = healthStat;
		StatsManager.hungerStat = hungerStat;
		StatsManager.thirstStat = thirstStat;
	}
	
	public Image healthPannel;
	public Texture2D healthTexture;
	public Image hungerPannel;
	public Texture2D hungerTexture;
	public Image thirstPannel;
	public Texture2D thirstTexture;
	public RectTransform pannel;
	
	// Use this for initialization
	void Start ()
	{
		pannel = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnGUI()
	{
		//Debug.Log(healthPannel.GetPixelAdjustedRect().x);
		GUI.BeginGroup(pannel.rect);
		GUI.DrawTexture(new Rect(healthPannel.GetPixelAdjustedRect().x, healthPannel.GetPixelAdjustedRect().y, healthPannel.GetPixelAdjustedRect().width/2, healthPannel.GetPixelAdjustedRect().height), healthTexture);
		GUI.EndGroup();
	}
}
